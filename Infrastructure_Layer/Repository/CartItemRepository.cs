using Application_Layer.Interfaces.CartItemInterfaces;
using Domain_Layer.Models;
using Infrastructure_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Repositories.Implementations
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly AppDbContext _db;

        public CartItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<CartItem> CreateAsync(CartItem item)
        {
            _db.CartItems.Add(item);
            await _db.SaveChangesAsync();
            return item;
        }

        public Task<CartItem> CreateCartItemAsync(CartItem cartItem)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await _db.CartItems.FindAsync(id);
            if (item == null) return false;

            _db.CartItems.Remove(item);
            await _db.SaveChangesAsync();
            return true;
        }

        public Task<bool> DeleteCartItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CartItem>> GetAllAsync()
        {
            return await _db.CartItems.ToListAsync();
        }

        public Task<List<CartItem>> GetAllCartItemsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await _db.CartItems.FindAsync(id);
        }

        public Task<CartItem?> GetCartItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(CartItem item)
        {
            _db.CartItems.Update(item);
            await _db.SaveChangesAsync();
        }

        public Task UpdateCartItemAsync(CartItem cartItem)
        {
            throw new NotImplementedException();
        }
    }
}
