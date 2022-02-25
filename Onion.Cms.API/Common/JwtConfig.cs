namespace Onion.Cms.API.Common
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public int Expires { get; set; }
    }
}