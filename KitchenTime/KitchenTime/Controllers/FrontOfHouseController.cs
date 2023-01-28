using Microsoft.AspNetCore.Mvc;
using RestaurantTime.Kitchen.Services.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Shared.Models;

namespace RestaurantTime.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FrontOfHouseController : ControllerBase
    {
        private readonly ILogger<FrontOfHouseController> _logger;
        private readonly ICreateOrderService _createOrderService;

        public FrontOfHouseController(
            ILogger<FrontOfHouseController> logger, 
            ICreateOrderService createOrderService
            )
        {
            _logger = logger;
        }

        [HttpPost(Name = "TakeOrder")]
        public Order TakeOrder(CreateOrderDto dto)
        {
            var x = await _createOrderService.CreateKichenTicket();

            return 
        }

        //[HttpPut(Name = "AmendOrder")]
        //public IEnumerable<WeatherForecast> AmendOrder()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet(Name = "RecallOrder")]
        //public IEnumerable<WeatherForecast> RecallOrder()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        //[HttpGet(Name = "TakePlatesOut")]
        //public IEnumerable<WeatherForecast> TakePlatesOut()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        //[HttpGet(Name = "CollectPlates")]
        //public IEnumerable<WeatherForecast> CollectPlates()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
    }
}