using System;

namespace ProxyApp
{
    class CurrencyRate
    {
        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public decimal Cur_OfficialRate { get; set; }
        public void WriteCurRate()
        {
            Console.WriteLine($"Currency Abbreviation={this.Cur_Abbreviation}");
            Console.WriteLine($"Date={this.Date}");
            Console.WriteLine($"Scale={this.Cur_Scale}");
            Console.WriteLine($"Currency Name={this.Cur_Name}");
            Console.WriteLine($"Official Rate={this.Cur_OfficialRate}");
        }
    }
}
