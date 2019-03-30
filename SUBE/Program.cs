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
                decimal total = 0;
                int tripsCount = 0;

                foreach (var item in movements)
                {
                    if(!Movement.IsCarga(item.Type))
                    {
                        total += item.Value;
                        tripsCount++;
                    }
                }
                Console.WriteLine("Total: ${0}, Movimientos: {1}", total, tripsCount);
            }
        }
    }
}

