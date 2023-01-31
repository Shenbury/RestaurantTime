using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Database.Services.Interfaces
{
    public interface IOrderRepository
    {
        Task<GetOrderDto> Create(CreateOrderDto dto);
    }
}
