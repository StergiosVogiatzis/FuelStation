using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelStation.Model
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime HireDateStart { get; set; }
        public DateTime HireDateEnd { get; set; }
        public decimal Sallary { get; set; }
        public EmployeeType EmployeeType { get; set; }
        public Employee()
        {

        }

    }
}
