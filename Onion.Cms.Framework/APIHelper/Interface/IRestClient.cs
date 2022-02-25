using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;

namespace Onion.Cms.Framework.APIHelper.Interface
{
    public interface IRestClient
    {
        //Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers, object body, Dictionary<string, string> queryParameter = null);

        public Task<T> SendHttpRequestAsync<T>(Method httpMethod, string requestUrl,
            Dictionary<string, string> headers, object body,
            Dictionary<string, string> queryParameter = null);
        public Task<IRestResponse<T>> SendHttpRequestRestAsync<T>(Method httpMethod, string requestUrl,
            Dictionary<string, string> headers, object body,
            Dictionary<string, string> queryParameter = null);
    }
}