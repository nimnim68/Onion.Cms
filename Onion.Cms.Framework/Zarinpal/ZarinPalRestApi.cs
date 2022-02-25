using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace Onion.Cms.Framework.Zarinpal
{
    public static class ZarinPalRestApi
    {
        private static readonly HttpClient HttpClient = new HttpClient();

        private static readonly string BaseUrlSandBox = "https://sandbox.zarinpal.com";//For debug and test.
        private static readonly string BaseUrl = "https://www.zarinpal.com";//For publish.

        public static ZarinpalModel.Payment.Response PaymentRequest(ZarinpalModel.Payment.Request request)
        {
            var baseUrl = BaseUrl;
#if DEBUG
            baseUrl = BaseUrlSandBox;
#endif
            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "ZarinPal Rest Api v1");

            var serializeObject = JsonConvert.SerializeObject(request);

            var stringContent = new StringContent(serializeObject, Encoding.UTF8, "application/json");

            var httpResponseMessage = HttpClient.PostAsync($"{baseUrl}/pg/rest/WebGate/PaymentRequest.json", stringContent).Result;

            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ZarinpalModel.Payment.Response>(result);
        }

        public static ZarinpalModel.PaymentVerification.Response PaymentVerification(ZarinpalModel.PaymentVerification.Request request)
        {

            HttpClient.DefaultRequestHeaders.Accept.Clear();
            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpClient.DefaultRequestHeaders.Add("User-Agent", "ZarinPal Rest Api v1");
            var baseUrl = BaseUrl;
#if DEBUG
            baseUrl = BaseUrlSandBox;
#endif
            var serializeObject = JsonConvert.SerializeObject(request);

            var stringContent = new StringContent(serializeObject, Encoding.UTF8, "application/json");

            var httpResponseMessage = HttpClient.PostAsync($"{baseUrl}/pg/rest/WebGate/PaymentVerification.json", stringContent).Result;

            var result = httpResponseMessage.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<ZarinpalModel.PaymentVerification.Response>(result);
        }
    }
}
