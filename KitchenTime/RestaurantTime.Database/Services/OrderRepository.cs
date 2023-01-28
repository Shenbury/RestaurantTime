using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Database.Services
{
    internal class OrderRepository : IOrderRepository
    {
        public async Task<GetOrderDto> Create(CreateOrderDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
