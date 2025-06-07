using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain_Layer.Entities;

namespace Domain_Layer.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public int UserId { get; set; } // Koppling till användare

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        public decimal TotalAmount { get; set; }

        public string? Status { get; set; } // Exempel: "Pending", "Completed"

        // Navigation properties (t.ex. en lista av OrderItems)
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
