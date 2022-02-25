using System;
using System.Net;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Onion.Cms.Web.Middleware
{
    public class RequestHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestHandlerMiddleware(RequestDelegate next, ILogger logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            _logger.Log(LogLevel.Information, new EventId(1, "RequestHandlerMiddleware.StartRequest"), context, null, null);
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleException(context, ExceptionDispatchInfo.Capture(exception));
            }
            finally
            {
                _logger.Log(LogLevel.Information, new EventId(2, "RequestHandlerMiddleware.EndRequest"), context, null, null);
            }
        }

        private async Task HandleException(HttpContext context, ExceptionDispatchInfo edi)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(JsonConvert.SerializeObject(
                new
                {
                    Success = false,
                    Messages = edi.SourceException.InnerException?.Message ?? edi.SourceException.Message,
                }, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                })
            );
        }

    }
}