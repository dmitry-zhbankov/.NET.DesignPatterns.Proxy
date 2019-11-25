using System;
using System.Net.Http;
using System.Text.Json;

namespace ProxyApp
{
    class YesterdayRate : IYesterdayRate
    {
        public CurrencyRate GetRate()
        {
            Console.WriteLine("Getting new currency rate");

            DateTime yesterday = DateTime.Now.AddDays(-1).Date;
            string strDate = $"{yesterday.Year}-{yesterday.Month}-{yesterday.Day}";
            var request = new HttpRequestMessage(HttpMethod.Get, $@"http://www.nbrb.by/API/ExRates/Rates/145?onDate={strDate}");

            var client = new HttpClient();
            HttpResponseMessage response;
            try
            {
                response = client.SendAsync(request).GetAwaiter().GetResult();
            }
            catch
            {
                throw new HttpRequestException($"Request failed: {request.RequestUri}");
            }

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new HttpRequestException($"Request failed: {request.RequestUri}. Wrong response status code: {response.StatusCode}");

            string res;
            try
            {
                res = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }
            catch (Exception)
            {
                throw new HttpRequestException($"Request response read failed: {request.RequestUri}");
            }

            CurrencyRate curRate;
            try
            {
                curRate = JsonSerializer.Deserialize<CurrencyRate>(res);
            }
            catch
            {
                throw new JsonException("Json deserialization failed");
            }

            request.Dispose();
            client.Dispose();
            response.Dispose();

            return curRate;
        }
    }
}
