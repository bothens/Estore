csharp Infrastructure_Layer\Repository\ProductRepository.cs
using Application_Layer.Interfaces.ProductInterfaces;
using Domain_Layer.Models;
using Infrastructure_Layer.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure_Layer.Repositories.Implementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _db;

        public ProductRepository(AppDbContext db)
        {
            _db = db;
        }

        // existing helper methods - kept as-is
        public async Task<Product> CreateAsync(Product product)
        {
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _db.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
        }

        public async Task<bool> ProductExistsAsync(int productId)
        {
            return await _db.Products.AnyAsync(p => p.ProductId == productId);
        }

        // Implementations required by IProductRepository
        public async Task<Product> AddProductAsync(Product product)
        {
            // Delegate to the existing CreateAsync
            return await CreateAsync(product);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await GetAllAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            await UpdateAsync(product);
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<Product?> RemoveProductAsync(int id)
        {
            var product = await GetByIdAsync(id);
            if (product == null) return null;
            await DeleteAsync(product);
            return product;
        }
    }
}