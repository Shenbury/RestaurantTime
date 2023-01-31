using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Database.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task<GetOrderDto> Create(CreateOrderDto dto);
    }
}
