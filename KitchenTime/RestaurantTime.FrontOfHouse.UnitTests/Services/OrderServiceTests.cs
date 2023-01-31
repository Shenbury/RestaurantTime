using RestaurantTime.TestingLibraries.UnitTestFramework;
using RestaurantTime.FrontOfHouse.Services.Services;
using Microsoft.Extensions.Logging.Abstractions;
using RestaurantTime.Database.Services;
using RestaurantTime.Database;
using RestaurantTime.Shared.Dtos.OrderDto;

namespace RestaurantTime.FrontOfHouse.Services.UnitTests.Services
{
    public class OrderServiceTests
    {
        private RestaurantDbContext _restaurantDbContext;
        private OrderService _orderService;

        public OrderServiceTests()
        {
            SetupCleanOrderService();
        }

        [Theory]
        [InlineData()]
        public async Task CanCreateOrder_WithFreshOrder()
        {
            //// Arrange
            //var createOrderDto = new CreateOrderDto();

            //// Act
            //var getOrderDto = await _orderService.CreateOrder(createOrderDto);

            //// Assert
            //Assert.NotNull(createOrderDto);
        }

        [Theory]
        [InlineData()]
        public void CantCreateOrder_With_()
        {

        }

        private void SetupCleanOrderService()
        {
            _restaurantDbContext =
            new InMemoryRestaurantDbContext()
            .Initialize();

            var repo = new OrderRepository(_restaurantDbContext, new NullLogger<OrderRepository>());
            _orderService = new OrderService(repo, new NullLogger<OrderService>());
        }
    }
}