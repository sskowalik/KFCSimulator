using System.Collections.Generic;

namespace KFCSimulator.Models
{
    public class OrderItem
    {
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
