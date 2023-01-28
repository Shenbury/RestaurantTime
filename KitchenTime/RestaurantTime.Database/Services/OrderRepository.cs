using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Shared.Dtos.OrderDto.Extensions;
using RestaurantTime.Shared.Models;
using System.Reflection.Metadata;

namespace RestaurantTime.Database.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly RestaurantDbContext _restaurantDb;

        public OrderRepository(RestaurantDbContext restaurantDb)
        {
            restaurantDb = _restaurantDb;
        }

        public async Task<GetOrderDto> Create(CreateOrderDto dto)
        {
            var order = dto.ToOrderModel();

            var entity = await _restaurantDb.AddAsync<Order>(order);

            order


        }
    }
}
