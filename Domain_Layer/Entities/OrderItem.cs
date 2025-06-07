﻿using Domain_Layer.Models;

namespace Domain_Layer.Entities
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public int ProductId { get; set; }
        public Product? Product { get; set; }

        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public decimal TotalPrice => (Product?.Price ?? 0) * Quantity;
    }
}
