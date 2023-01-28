using Microsoft.AspNetCore.Mvc;
using RestaurantTime.Shared.Dtos.OrderDto;

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

        //[HttpPut(Name = "CookFood")]
        //public IEnumerable<WeatherForecast> CookFood()
        //{

        //}

        //[HttpGet(Name = "GetOrderStatus")]
        //public IEnumerable<WeatherForecast> GetOrderStatus()
        //{

        //}
    }
}