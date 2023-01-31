using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Shared.Dtos.OrderDto.Extensions;
using RestaurantTime.Shared.Dtos.OrderDto.Validators;
using RestaurantTime.Shared.Models;

namespace RestaurantTime.Database.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _restaurantDb;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(RestaurantDbContext restaurantDb, ILogger<OrderRepository> logger)
        {
            _restaurantDb = restaurantDb;
            _logger = logger;

        }

        public async Task<GetOrderDto> Create(CreateOrderDto dto)
        {
            _logger.LogInformation($"Entered order repository for WaiterId: {dto.WaiterId}");
            var order = dto.ToOrderModel();
            _logger.LogInformation($"Converted {nameof(CreateOrderDto)} to order model for WaiterId:{dto.WaiterId}");

            var entity = await _restaurantDb.AddAsync<Order>(order);
            await _restaurantDb.SaveChangesAsync();

            // Added fetch due to not fetching join tables and 
            var fetchedEntity = await _restaurantDb.Orders
                .Include(o => o.Drinks)
                .Include(o => o.Foods)
                .SingleAsync(o => o.Id == order.Id);

            _logger.LogInformation($"Saved {nameof(Order)} entity to OrderId: {order.Id}");

            var response = order.ToGetOrderDto();

            _logger.LogInformation($"Converted to {nameof(GetOrderDto)} for OrderId: {order.Id}");

            response.Validate();

            _logger.LogInformation($"Validated {nameof(GetOrderDto)} for OrderId: {order.Id}");

            return response;
        }
    }
}
