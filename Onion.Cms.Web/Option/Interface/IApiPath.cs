namespace Onion.Cms.Web.Option.Interface
{
    public interface IApiPath
    {
        public string BaseUrl { get; set; }
        public string LoginPath { get; set; }
        public string GetOrderPath { get; set; }
    }
}