using AutoMapper;
using Data.Models;
using Data.RepoInterfaces;
using Service.RequestModels;
using Service.ResponseModels;
using Service.ServiceInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<OrderResponse>> GetOrdersAsync()
        {
            var orders = await _repo.GetOrdersAsync();

            return _mapper.Map<List<OrderResponse>>(orders);
        }

        public async Task<OrderResponse> GetOrderByIdAsync(int orderId)
        {
            var order = await _repo.GetOrderByIdAsync(orderId);

            if (order == null)
                return null;

            return _mapper.Map<OrderResponse>(order);
        }

        public async Task<OrderResponse> CreateOrderAsync(CreateOrder createOrder)
        {
            var newOrder = _mapper.Map<Order>(createOrder);

            var created = await _repo.CreateOrderAsync(newOrder);

            if (!created)
                return null;

            return await GetOrderByIdAsync(newOrder.Id);
        }

        public async Task<OrderResponse> UpdateOrderAsync(int orderId, UpdateOrder orderToUpdate)
        {
            var updatedOrder = _mapper.Map<Order>(orderToUpdate);
            updatedOrder.Id = orderId;

            var updated = await _repo.UpdateOrderAsync(updatedOrder);

            if (!updated)
                return null;

            return await GetOrderByIdAsync(updatedOrder.Id);
        }

        public async Task<bool> DeleteOrderAsync(int orderId)
        {
            return await _repo.DeleteOrderAsync(orderId);
        }
    }
}
