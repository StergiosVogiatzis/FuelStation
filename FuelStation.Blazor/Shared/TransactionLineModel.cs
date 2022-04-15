using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;

namespace FuelStation.Blazor.Shared
{
    public class TransactionLineViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid TransactionID { get; set; }
        public Transaction Transaction { get; set; }
        public Guid ItemID { get; set; }
        public Item Item { get; set; }
        public ItemType ItemType { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
        public decimal NetValue { get; set; }
        public decimal DiscountPercent { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal TotalValue { get; set; }
        public List<TransactionViewModel> Transactions { get; set; }
        public List<ItemViewModel> Items { get; set; }
    }
}
