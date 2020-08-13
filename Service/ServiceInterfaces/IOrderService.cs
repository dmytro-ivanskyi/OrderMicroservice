using Service.RequestModels;
using Service.ResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.ServiceInterfaces
{
    public interface IOrderService
    {
        Task<List<OrderResponse>> GetOrdersAsync();

        Task<OrderResponse> GetOrderByIdAsync(int orderId);

        Task<OrderResponse> CreateOrderAsync(CreateOrder createOrder);

        Task<OrderResponse> UpdateOrderAsync(int orderId, UpdateOrder orderToUpdate);

        Task<bool> DeleteOrderAsync(int orderId);
    }
}
