using System;
using System.Net.Http;
using System.Text.Json;

namespace ProxyApp
{
    class YesterdayRate : IYesterdayRate
    {
        public CurrencyRate GetRate()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1).Date;
            string strDate = $"{yesterday.Year}-{yesterday.Month}-{yesterday.Day}";
            var request = new HttpRequestMessage(HttpMethod.Get, $@"http://www.nbrb.by/API/ExRates/Rates/145?onDate={strDate}");
            var client = new HttpClient();
            HttpResponseMessage response = client.SendAsync(request).Result;
            HttpContent content = response.Content;
            string res = content.ReadAsStringAsync().Result;
            CurrencyRate curRate = JsonSerializer.Deserialize<CurrencyRate>(res);
            Console.WriteLine("Getting new currency rate");
            return curRate;
        }
    }
}
