using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;

namespace FuelStation.Blazor.Shared
{
    public class EmployeeViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HireDateStart { get; set; } = DateTime.Now;
        public DateTime? HireDateEnd { get; set; }
        public decimal Sallary { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
    public class EmployeeEditViewModel
    {
        public Guid ID { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HireDateStart { get; set; } = DateTime.Now;
        public DateTime HireDateEnd { get; set; }
        public decimal Sallary { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
