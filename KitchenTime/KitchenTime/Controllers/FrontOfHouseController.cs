using Microsoft.AspNetCore.Mvc;
using RestaurantTime.Kitchen.Services.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Shared.Dtos.OrderDto.Validators;

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
            _orderService = orderService;
        }

        [HttpPost]
        [Route("CreateOrder")]
        public async Task<GetOrderDto> CreateOrder(CreateOrderDto dto)
        {
            _logger.LogInformation($"Validating {nameof(CreateOrderDto)}");
            dto.Validate();
            _logger.LogInformation($"Received request to create order for waiter {dto.WaiterId}");

            var order = await _orderService.CreateOrder(dto);
            _logger.LogInformation($"Returning order by id {order.Id}");

            return order;
        }
    }
}