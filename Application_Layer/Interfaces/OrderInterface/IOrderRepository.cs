using Domain_Layer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Interfaces.OrderInterface
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order> AddOrderAsync(Order order);

        Task<Order> GetOrderByIdAsync(int orderId);
        Task<bool> UpdateOrderAsync(Order existingOrder);
        Task<Order?> RemoveOrderAsync(int orderId);
    }
}
