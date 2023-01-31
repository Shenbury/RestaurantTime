using RestaurantTime.TestingLibraries.UnitTestFramework;
using RestaurantTime.FrontOfHouse.Services.Services;
using Microsoft.Extensions.Logging.Abstractions;
using RestaurantTime.Database.Services;
using RestaurantTime.Database;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.TestingLibraries.MockData;

namespace RestaurantTime.FrontOfHouse.Services.UnitTests.Services
{
    public class OrderServiceTests
    {
        private RestaurantDbContext _restaurantDbContext;
        private OrderService _orderService;

        public OrderServiceTests()
        {
            Task.Run(() => SetupCleanOrderService()).Wait();
        }

        [Theory]
        [InlineData()]
        public async Task CanCreateOrder_WithFreshOrderData()
        {
            // Arrange
            var createOrderDto = new CreateOrderDto(1, 1, new List<int>(1), new List<int>(1), DateTime.Now, null);

            // Act
            var getOrderDto = await _orderService.CreateOrder(createOrderDto);

            // Assert
            Assert.NotNull(getOrderDto);
        }

        [Theory]
        [InlineData()]
        public void CantCreateOrder_With_()
        {

        }

        private async Task SetupCleanOrderService()
        {
            _restaurantDbContext =
            new InMemoryRestaurantDbContext()
            .Initialize();

            await new BaseDataToRestaurantDbContext().AddAdditionalBaseDataToDbContext(_restaurantDbContext);

            var repo = new OrderRepository(_restaurantDbContext, new NullLogger<OrderRepository>());
            _orderService = new OrderService(repo, new NullLogger<OrderService>());
        }
    }
}