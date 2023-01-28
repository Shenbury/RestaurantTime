using Microsoft.AspNetCore.Mvc;
using RestaurantTime.Kitchen.Services.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrontOfHouseController : ControllerBase
    {
        private readonly ILogger<FrontOfHouseController> _logger;
        private readonly IOrderService _orderService;

        public FrontOfHouseController
            (
                ILogger<FrontOfHouseController> logger,
                IOrderService orderService
            )
        {
            _logger = logger;
        }

        [HttpPost(Name = "TakeOrder")]
        public async Task<GetOrderDto> TakeOrder(CreateOrderDto dto)
        {
            var order = await _orderService.CreateOrder(dto);

            return order;
        }
    }
}