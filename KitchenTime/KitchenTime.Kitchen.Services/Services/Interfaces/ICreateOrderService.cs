using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Kitchen.Services.Services.Interfaces
{
    public interface ICreateOrderService
    {
        Task<GetOrderDto> CreateOrderDto(CreateOrderDto dto);
    }
}
