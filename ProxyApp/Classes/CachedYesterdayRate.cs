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
            yesterdayRate = new YesterdayRate();
            cachedRates = new Dictionary<DateTime, CurrencyRate>();
        }

        public CurrencyRate GetRate()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1).Date;
            if (cachedRates.ContainsKey(yesterday))
            {
                Console.WriteLine("Getting currency rate from cache");
                return cachedRates[yesterday];
            }

            CurrencyRate res = null;
            try
            {
                res = yesterdayRate.GetRate();
                cachedRates.Add(yesterday, res);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error. ExeptionType={ex.GetType()}. ExeptionMessage=\"{ex.Message}\"");
            }
            return res;
        }
    }
}
