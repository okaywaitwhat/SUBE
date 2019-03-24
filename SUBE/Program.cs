using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using static SUBE.Models.Outgoings;
using static SUBE.Movements;

namespace SUBE
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("Data/Movements.json"))
            {
                string json = r.ReadToEnd();
                List<Movement> movements = JsonConvert.DeserializeObject<List<Movement>>(json);

                var byMonth = movements
                .GroupBy(x => new { Month = x.Date.Month, Year = x.Date.Year})
                .ToDictionary(g => g.Key, g => g.Count());

                foreach(var item in byMonth)
                {
                    Console.WriteLine("Total viajes: {0} Mes: {1}/{2}", item.Value, item.Key.Month, item.Key.Year);
                }

                var JanuaryMovements = movements
                .Where(m => m.Date.Month == 01);

                decimal total = 0;
                int travelCount = 0;

                foreach (Movement m in JanuaryMovements)
                {
                    travelCount += 1;
                    total += m.BalanceFormat;
                }

                Outgoing JanuaryOutGoings = new Outgoing();

                JanuaryOutGoings.Month = 1;
                JanuaryOutGoings.TotalTravels = travelCount;
                JanuaryOutGoings.Total = total;

                //Console.WriteLine("Mes: {0}  Cantidad de viajes: {1}  Total: {2}", JanuaryOutGoings.Month, JanuaryOutGoings.TotalTravels, JanuaryOutGoings.Total);

                /*foreach (var item in movements)
                {
                    Console.WriteLine("{0} {1} {2} {3}", item.Date, item.ValueFormat, item.BalanceFormat, item.IsNegative);
                }

                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1} {2}", item.Date, item.ValueFormat, item.BalanceFormat);
                }*/
            }
        }
    }
}

