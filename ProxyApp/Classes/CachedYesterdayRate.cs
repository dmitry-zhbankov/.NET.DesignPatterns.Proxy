using System;
using System.Collections.Generic;

namespace ProxyApp
{
    class CachedYesterdayRate : IYesterdayRate
    {
        Dictionary<DateTime, CurrencyRate> cachedRates;
        YesterdayRate yesterdayRate;
        public CachedYesterdayRate()
        {
            cachedRates = new Dictionary<DateTime, CurrencyRate>();
        }
        public CurrencyRate GetRate()
        {
            if (yesterdayRate == null)
            {
                yesterdayRate = new YesterdayRate();
            }
            DateTime yesterday = DateTime.Now.AddDays(-1).Date;
            if (cachedRates.ContainsKey(yesterday))
            {
                Console.WriteLine("Getting currency rate from cache");
                return cachedRates[yesterday];
            }
            CurrencyRate res = yesterdayRate.GetRate();
            cachedRates.Add(yesterday, res);
            return res;
        }
    }
}
