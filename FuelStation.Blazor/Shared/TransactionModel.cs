using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;

namespace FuelStation.Blazor.Shared
{
    public class TransactionViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.Now;
        public Guid EmployeeID { get; set; }
        public string EmployeeSurname { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerSurname { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }
        public List<EmployeeViewModel> Employees { get; set; } = new();
        public List<CustomerViewModel> Customers { get; set; } = new();
        public List<TransactionLineViewModel> TransactionLines { get; set; } = new();
    }
    public class TransactionEditViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; } = DateTime.Now;
        public Guid EmployeeID { get; set; }
        public string EmployeeSurname { get; set; }
        public Guid CustomerID { get; set; }
        public string CustomerSurname { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public decimal TotalValue { get; set; }
        public List<EmployeeViewModel> Employees { get; set; } = new();
        public List<CustomerViewModel> Customers { get; set; } = new();
        public List<TransactionLineViewModel> TransactionLines { get; set; } = new();
    }

}
