using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Onion.Cms.Framework.APIHelper.Interface;

namespace Onion.Cms.Framework.APIHelper
{
    public class Client : BaseHttpClient, IClient
    {
        public Client(HttpClient httpClient, string baseUrl) : base(httpClient, baseUrl)
        {
        }

        public Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers, object body,
            Dictionary<string, string> queryParameter = null)
        {
            return base.SendRequestAsync<T>(httpMethod, requestUrl, headers, body, queryParameter);
        }

        public Task<T> SendHttpRequestWithKeyPairValueBodyAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers,
            object body, Dictionary<string, string> queryParameter)
        {
            return base.SendRequestAsync<T>(httpMethod, requestUrl, headers, body, queryParameter);
        }
    }
}