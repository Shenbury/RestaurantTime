using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.FrontOfHouse.Services.Services.Interfaces
{
    public interface IOrderService
    {
        Task<GetOrderDto> CreateOrder(CreateOrderDto dto);
    }
}
