using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Onion.Cms.Framework.Helper;
using Onion.Cms.Web.Common.APIHelper;
using Onion.Cms.Web.Models.Auth;
using Onion.Cms.Web.Option;
using RestSharp;
using IRestClient = Onion.Cms.Framework.APIHelper.Interface.IRestClient;

namespace Onion.Cms.Web.Controllers
{
    public class RestApiController : Controller
    {
        private readonly IRestClient _client;
        private readonly ApiPath _apiPath;

        public RestApiController(IRestClient client, IOptionsMonitor<ApiPath> apiPath)
        {
            _client = client;
            _apiPath = apiPath.CurrentValue;
        }

        public async Task<IActionResult> Index()
        {
            //string accessToken = await HttpContext.GetTokenAsync("access_token");
            //string refreshToken = await HttpContext.GetTokenAsync("refresh_token");
            var header = new Dictionary<string, string>() { };
            var queryParameter = new Dictionary<string, string>()
            {
                {"Email" , "admin@admin.com"} ,
                {"Password" , "Mr@123"}  ,
                {"RememberMe" , "true"}
            };
            var res = await _client.SendHttpRequestAsync<AuthenticationModel>(Method.GET, _apiPath.LoginPath, header, null, queryParameter);
            HttpContext.Session.SetString("JWToken", res.Token);
            return View();
        }
        public async Task<IActionResult> Order()
        {
            //string accessToken = await HttpContext.GetTokenAsync("access_token");
            //string refreshToken = await HttpContext.GetTokenAsync("refresh_token");

            var accessToken = HttpContext.Session.GetString("JWToken");
            var header = APIUtility.GenerateHeader(accessToken);
            var body = new
            {
                Email = "admin@admin.com",
                Password = "M@123",
                RememberMe = true
            };
            var res = await _client.SendHttpRequestAsync<string>(Method.POST, _apiPath.GetOrderPath, header, body);
            return View();
        }
    }
}
