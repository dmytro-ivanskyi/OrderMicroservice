using AutoMapper;
using Data.Models;
using Service.RequestModels;
using Service.ResponseModels;

namespace Service.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<CreateOrder, Order>();
            CreateMap<UpdateOrder, Order>();

            CreateMap<Order, OrderResponse>();
        }
    }
}
