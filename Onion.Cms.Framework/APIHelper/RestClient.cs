using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Onion.Cms.Framework.Helper;
using RestSharp;
using RestSharp.Authenticators;
using IRestClient = Onion.Cms.Framework.APIHelper.Interface.IRestClient;

namespace Onion.Cms.Framework.APIHelper
{
    public class RestApiClient : IRestClient
    {
        private readonly string _baseUrl;

        public RestApiClient(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<T> SendHttpRequestAsync<T>(Method httpMethod, string requestUrl, Dictionary<string, string> headers, object body = null,
            Dictionary<string, string> queryParameter = null)
        {
            var queryResult = await Get<T>(httpMethod, requestUrl, headers, body, queryParameter);
            return queryResult.Data;

        }

        public async Task<IRestResponse<T>> SendHttpRequestRestAsync<T>(
            Method httpMethod, string requestUrl,
            Dictionary<string, string> headers,
            object body = null, Dictionary<string, string> queryParameter = null)
        {
            return await Get<T>(httpMethod, requestUrl, headers, body, queryParameter);
        }

        private async Task<IRestResponse<T>> Get<T>(Method httpMethod, string requestUrl, Dictionary<string, string> headers, object body = null,
    Dictionary<string, string> queryParameter = null)
        {
            var rClient = new RestClient(_baseUrl);
            var request = new RestRequest(requestUrl, httpMethod) { RequestFormat = DataFormat.Json };
            request.AddHeaders(headers);

            if (body != null)
            {
                request.AddJsonBody(body);
                var serializedBody = JsonConvert.SerializeObject(body); // for log
            }

            if (queryParameter != null)
            {
                var serializedQueryParameter = JsonConvert.SerializeObject(queryParameter); // for log
                foreach (var item in queryParameter)
                {
                    request.AddQueryParameter(item.Key, item.Value);
                }
            }
            var queryResult = await rClient.ExecuteAsync<T>(request);
            var serializedResult = JsonConvert.SerializeObject(queryResult.Data); //for log
            return queryResult;
        }
    }
}