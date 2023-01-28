using Microsoft.Extensions.Logging;
using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.FrontOfHouse.Services.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.FrontOfHouse.Services.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _logger = logger;
        }

        public async Task<GetOrderDto> CreateOrder(CreateOrderDto dto)
        {
            _logger.LogInformation($"Enting order service for WaiterId {dto.WaiterId}");
            var order = await _orderRepository.Create(dto);
            _logger.LogInformation($"Returning from order service for OrderId {order.Id}");
            return order;
        }
    }
}
