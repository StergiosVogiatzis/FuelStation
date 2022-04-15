using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FuelStation.Model;

namespace FuelStation.Blazor.Shared
{
    public class ItemViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
    public class ItemEditViewModel
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string Code { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }
        public decimal Price { get; set; }
        public decimal Cost { get; set; }
    }
}
