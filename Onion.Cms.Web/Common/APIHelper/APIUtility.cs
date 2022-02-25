using System.Collections.Generic;

namespace Onion.Cms.Web.Common.APIHelper
{
    public static class APIUtility
    {
        public static Dictionary<string, string> GenerateHeader(string accessToken)
        {
            return new Dictionary<string, string>
            {
                {"Content-Type", "application/json" },
                {"Authorization",$"Bearer {accessToken}" }
            };
        }
    }
}