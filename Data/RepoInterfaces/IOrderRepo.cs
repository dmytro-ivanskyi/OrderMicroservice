using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.RepoInterfaces
{
    public interface IOrderRepo
    {
        Task<List<Order>> GetOrdersAsync();

        Task<Order> GetOrderByIdAsync(int orderId);

        Task<bool> CreateOrderAsync(Order order);

        Task<bool> UpdateOrderAsync(Order orderToUpdate);

        Task<bool> DeleteOrderAsync(int orderId);
    }
}
