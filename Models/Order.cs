using System;
using System.Collections.Generic;

namespace KFCSimulator.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderTime { get; set; }
        public List<OrderItem> Items { get; set; }
        public decimal TotalPrice { get; set; }
        public bool IsCompleted { get; set; }
    }

    
}