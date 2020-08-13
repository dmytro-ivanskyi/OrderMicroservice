using Data.Models;
using Data.RepoInterfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class OrderRepo : IOrderRepo
    {
        private readonly DataContext _data;

        public OrderRepo(DataContext context)
        {
            _data = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _data.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _data.Orders.SingleOrDefaultAsync(x => x.Id == orderId);
        }

        public async Task<bool> CreateOrderAsync(Order order)
        {
            await _data.Orders.AddAsync(order);

            var created = await _data.SaveChangesAsync();

            return created > 0;
        }

        public async Task<bool> UpdateOrderAsync(Order orderToUpdate)
        {
            _data.Orders.Update(orderToUpdate);

            var updated = await _data.SaveChangesAsync();

            return updated > 0;
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            var order = await GetOrderByIdAsync(orderId);

            if (order == null)
                return false;

            _data.Orders.Remove(order);
            var deleted = await _data.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
