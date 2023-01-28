using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Kitchen.Services.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Kitchen.Services.Services
{
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderDto> CreateOrderDto(CreateOrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
