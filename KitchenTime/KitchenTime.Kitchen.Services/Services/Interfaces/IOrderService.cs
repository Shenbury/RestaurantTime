using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Kitchen.Services.Services.Interfaces
{
    public interface IOrderService
    {
        Task<GetOrderDto> CreateOrder(CreateOrderDto dto);
    }
}
