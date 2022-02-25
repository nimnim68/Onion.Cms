using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Onion.Cms.Framework.Helper;

namespace Onion.Cms.Framework.APIHelper
{
    public class BaseHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public BaseHttpClient(HttpClient httpClient, string baseUrl)
        {
            _httpClient = httpClient;
            _baseUrl = baseUrl;
        }
        protected Task<T> SendRequestAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers, object body, Dictionary<string, string> queryParameter = null)
        {
            var serializedBody = JsonConvert.SerializeObject(body); // for log
            var serializedQueryParameter = JsonConvert.SerializeObject(queryParameter); // for log
            return SendRequestAsync<T>(httpMethod, requestUrl, headers, body.ToKeyValuePair, queryParameter);
        }
        private async Task<T> SendRequestAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers,
            Func<List<KeyValuePair<string, string>>> makeBody, Dictionary<string, string> queryParameter = null)
        {
            var uriBuilder = new UriBuilder(_baseUrl)
            {
                Path = requestUrl
            };
            if (queryParameter != null && queryParameter.Any())
            {
                var query = queryParameter.Aggregate(HttpUtility.ParseQueryString(uriBuilder.Query),
                    (collection, parameter) =>
                    {
                        collection.Add(parameter.Key, parameter.Value);
                        return collection;
                    });
                uriBuilder.Query = query.ToString() ?? string.Empty;
            }

            using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, uriBuilder.Uri);
            foreach (var item in headers)
            {
                httpRequestMessage.Headers.Add(item.Key, item.Value);
            }

            var body = makeBody();
            if (body != null)
                httpRequestMessage.Content = new FormUrlEncodedContent(body);
            try
            {
                var httpResponseMessage = await _httpClient.SendAsync(httpRequestMessage);
                var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();

                if (httpResponseMessage.IsSuccessStatusCode)
                {
                    var result = JsonConvert.DeserializeObject<T>(responseContent);
                    var serializedResult = JsonConvert.SerializeObject(result);
                    return result;
                }

                throw new Exception();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}