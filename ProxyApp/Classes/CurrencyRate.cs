using System;
using System.Text.Json.Serialization;

namespace ProxyApp
{
    class CurrencyRate
    {
        [JsonPropertyName("Cur_ID")]
        public int CurId { get; set; }

        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("Cur_Abbreviation")]
        public string CurAbbreviation { get; set; }

        [JsonPropertyName("Cur_Scale")]
        public int CurScale { get; set; }

        [JsonPropertyName("Cur_Name")]
        public string CurName { get; set; }

        [JsonPropertyName("Cur_OfficialRate")]
        public decimal CurOfficialRate { get; set; }

        public void WriteCurRate()
        {
            Console.WriteLine($"Currency Abbreviation={this.CurAbbreviation}");
            Console.WriteLine($"Date={this.Date}");
            Console.WriteLine($"Scale={this.CurScale}");
            Console.WriteLine($"Currency Name={this.CurName}");
            Console.WriteLine($"Official Rate={this.CurOfficialRate}");
        }
    }
}
