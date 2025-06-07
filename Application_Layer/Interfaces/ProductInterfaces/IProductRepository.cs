using Domain_Layer.Models;

namespace Application_Layer.Interfaces.ProductInterfaces
{
    public interface IProductRepository
    {
        Task<Product> AddProductAsync(Product product);
        Task<List<Product>> GetAllProductsAsync();
        Task<bool> ProductExistsAsync(int productId);

        Task UpdateProductAsync(Product product);
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product?> RemoveProductAsync(int id);
       

    }
}
