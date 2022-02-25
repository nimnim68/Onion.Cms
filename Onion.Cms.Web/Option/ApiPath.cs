using Onion.Cms.Web.Option.Interface;

namespace Onion.Cms.Web.Option
{
    public class ApiPath : IApiPath
    {
        public string BaseUrl { get; set; }
        public string LoginPath { get; set; }
        public string GetOrderPath { get; set; }
    }
}