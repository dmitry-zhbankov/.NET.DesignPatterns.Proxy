using System;

namespace ProxyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Getting currency rate");
            CachedYesterdayRate cachedYesterdayRate = new CachedYesterdayRate();
            DateTime start = DateTime.Now;
            CurrencyRate curRate = cachedYesterdayRate.GetRate();
            DateTime end = DateTime.Now;
            TimeSpan dt = end - start;
            Console.WriteLine($"Time elapsed={dt.Milliseconds}ms");
            curRate.WriteCurRate();

            Console.WriteLine();

            Console.WriteLine("Getting currency rate again");
            start = DateTime.Now;
            curRate = cachedYesterdayRate.GetRate();
            end = DateTime.Now;
            dt = end - start;
            Console.WriteLine($"Time elapsed={dt.Milliseconds}ms");
            curRate.WriteCurRate();
            Console.ReadLine();
        }
    }
}
