using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SUBE
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader r = new StreamReader("Movements.json"))
            {
                string json = r.ReadToEnd();
                //List<Movement> items = JsonConvert.DeserializeObject<List<Movement>>(json);

                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1} {2}", item.Date, item.ValueFormat, item.BalanceFormat);
                }
            }
        }

        /*public class Movement
        {
            public string Date;
            public string Id;
            public string Type;
            public string Entity;
            public string Place;
            public string BalanceFormat;
            public string ValueFormat;
            public bool IsNegative;
            public bool IsNegativeBalance;
        }*/
    }
}

