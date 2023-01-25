using Microsoft.AspNetCore.Mvc;

namespace RestaurantTime.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KitchenController : ControllerBase
    {
        private readonly ILogger<KitchenController> _logger;

        public KitchenController(ILogger<KitchenController> logger)
        {
            _logger = logger;
        }

        [HttpPost(Name = "CreateKitchenTicket")]
        public IEnumerable<Order> CreateKitchenTicket(Order order, int waiterId)
        {

        }

        [HttpPut(Name = "CookFood")]
        public IEnumerable<WeatherForecast> CookFood()
        {

        }

        [HttpGet(Name = "GetTicketStatus")]
        public IEnumerable<WeatherForecast> GetOrderStatus()
        {

        }
    }
}