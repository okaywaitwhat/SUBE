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
                this.Month = Date.Month;
                this.Value = Convert.ToDecimal(BalanceFormat, culture);
                this.LeftBalance = Convert.ToDecimal(ValueFormat, culture);
                this.Type = Type;
            }

            public int Month;
            public decimal Value;
            public decimal LeftBalance;
            // public int Id;
            public string Type;
            // public string Entity;
            // public string Place;
            // public decimal BalanceFormat;
            // public decimal ValueFormat;
            // public bool IsNegativeBalance;

            public static bool IsCarga(string type)
            {
                return type == "Carga Electronica" || type == "Carga";
            }

        }
    }
}
