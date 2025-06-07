using Domain_Layer.Models;

namespace Application_Layer.Interfaces.CartItemInterfaces
{
    public interface ICartItemRepository
    {
        Task<CartItem> CreateCartItemAsync(CartItem cartItem);
        Task<List<CartItem>> GetAllCartItemsAsync();
        Task<CartItem?> GetCartItemByIdAsync(int id);
        Task UpdateCartItemAsync(CartItem cartItem);
        Task<bool> DeleteCartItemAsync(int id);
    }
}
