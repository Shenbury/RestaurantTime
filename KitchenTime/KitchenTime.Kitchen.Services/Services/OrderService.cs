using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Kitchen.Services.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Kitchen.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<GetOrderDto> CreateOrder(CreateOrderDto dto)
        {
            var order = await _orderRepository.Create(dto);

            return order;
        }
    }
}
