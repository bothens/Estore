using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Application_Layer.Dtos.ProductDtos
{
    public class CreateProductDto
    {

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public int StockQuantity { get; set; } = 0;

        [MaxLength(255)]
        public string ImageUrl { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }
    }
}
