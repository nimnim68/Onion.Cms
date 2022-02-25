using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Onion.Cms.Framework.APIHelper.Interface
{
    public interface IClient
    {
        Task<T> SendHttpRequestAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers, object body, Dictionary<string, string> queryParameter = null);
        Task<T> SendHttpRequestWithKeyPairValueBodyAsync<T>(HttpMethod httpMethod, string requestUrl, Dictionary<string, string> headers, object body, Dictionary<string, string> queryParameter);
    }
}