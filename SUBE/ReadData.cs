using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SUBE
{
    public class ReadData
    {
        public void LoadJson()
        {
            using (StreamReader r = new StreamReader("Movements.json"))
            {
                string json = r.ReadToEnd();
                List<Movement> items = JsonConvert.DeserializeObject<List<Movement>>(json);

                dynamic array = JsonConvert.DeserializeObject(json);
                foreach (var item in array)
                {
                    Console.WriteLine("{0} {1}", item.Date, item.ValueFormat);
                }
            }
        }

        public class Movement
        {
            public DateTime Date;
            public int ID;
            public string Entity;
            public string Place;
            public string BalanceFormat;
            public string ValueFormat;
        }
    }

}
