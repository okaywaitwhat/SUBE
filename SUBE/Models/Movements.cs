using System;
namespace SUBE
{
    public class Movements
    {
        public class Movement
        {
            public DateTime Date;
            public int Id;
            public string Type;
            public string Entity;
            public string Place;
            public decimal BalanceFormat;
            public decimal ValueFormat;
            public bool IsNegative;
            public bool IsNegativeBalance;
        }
    }
}
