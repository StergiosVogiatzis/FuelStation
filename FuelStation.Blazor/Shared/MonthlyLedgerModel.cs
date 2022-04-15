using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Blazor.Shared
{
    public class MonthlyLedgerViewModel
    {
        public Guid ID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
        public decimal RentCost { get; set; } = 5000;
        public MonthlyLedgerViewModel()
        {
            Year = DateTime.Now.ToString();
            Month = DateTime.Now.ToString();
        }
    }
    public class MonthlyLedgerEditViewModel
    {
        public Guid ID { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public decimal Total { get; set; }
        public decimal RentCost { get; set; }
        public MonthlyLedgerEditViewModel()
        {
            Year = DateTime.Now.ToString();
            Month = DateTime.Now.ToString();
        }
    }

}
