using System;
using System.Globalization;
using Newtonsoft.Json;

namespace SUBE
{
    public static class Movements
    {
        public class Movement
        {
            [JsonConstructor]
            public Movement(string ValueFormat, string BalanceFormat, string Type, DateTime Date)
            {
                var culture = new CultureInfo("es-ES");
                this.Day = Date.Day;
                this.Month = Date.Month;
                this.Year = Date.Year;
                this.Value = Convert.ToDecimal(BalanceFormat, culture);
                this.LeftBalance = Convert.ToDecimal(ValueFormat, culture);
                this.Type = Type;
            }

            public int Day;
            public int Month;
            public int Year;
            public decimal Value;
            public decimal LeftBalance;
            public string Type;

            public static bool IsCarga(string type)
            {
                return type == "Carga Electronica" || type == "Carga";
            }

        }
    }
}
