using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model
{
    public class MonthlyLedger
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
        public MonthlyLedger()
        {
            Year = DateTime.Now.Year.ToString();
            Month = DateTime.Now.Month.ToString();
        }
    }
}
