namespace Application_Layer.Dtos.CartItemDtos
{
    public class CartItemDto
    {
        public int CartItemId { get; set; } 
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime AddedAt { get; set; }
        public bool Success { get; set; }
    }
}
