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
            using (StreamReader r = new StreamReader("Data/May.json"))
            {
                string json = r.ReadToEnd();
                List<Movement> movements = JsonConvert.DeserializeObject<List<Movement>>(json);
                decimal total = 0;
                int tripsCount = 0;


                var trips = movements.Where(item => !Movement.IsCarga(item.Type));

                var tripsByMonth = trips
                .GroupBy(x => new { Day = x.Day, Month = x.Month, Year = x.Year })
                .ToDictionary(g => g.Key, g => g.Count());


                foreach (var trip in tripsByMonth)
                {
                    Console.WriteLine("Fecha: {0}/{1}/{2}, Viajes: {3}", trip.Key.Day, trip.Key.Month, trip.Key.Year, trip.Value);
                }

                foreach (var item in trips)
                {
                    total += item.Value;
                    tripsCount++;
                }
                Console.WriteLine("Total: ${0}, Movimientos: {1}", total, tripsCount);
            }
        }
    }
}

