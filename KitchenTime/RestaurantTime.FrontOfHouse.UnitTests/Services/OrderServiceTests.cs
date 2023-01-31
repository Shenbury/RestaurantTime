using RestaurantTime.TestingLibraries.UnitTestFramework;
using RestaurantTime.FrontOfHouse.Services.Services;
using Microsoft.Extensions.Logging.Abstractions;
using RestaurantTime.Database;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Database.Repositories;

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

        [Fact]
        public async Task CanCreateOrder_WithFreshOrderData()
        {
            // Arrange
            var createOrderDto = new CreateOrderDto(1, 1, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null);

            // Act
            var getOrderDto = await _orderService.CreateOrder(createOrderDto);

            // Assert
            Assert.Equal(createOrderDto.GuestId, getOrderDto.GuestId);
            Assert.Equal(createOrderDto.WaiterId, getOrderDto.WaiterId);
            Assert.Equal(createOrderDto.FoodIds.First(), getOrderDto.Food.First().Id);
            Assert.Equal(createOrderDto.DrinkIds.First(), getOrderDto.Drinks.First().Id);
            Assert.Equal(createOrderDto.HasOrderedFood, getOrderDto.HasOrderedFood);
            Assert.Equal(createOrderDto.InKitchen, getOrderDto.InKitchen);
            Assert.Equal(createOrderDto.PlatesTakenAway, getOrderDto.PlatesTakenAway);
            Assert.Equal(createOrderDto.BeenServed, getOrderDto.BeenServed);
        }

        [Theory]
        [InlineData(null, 1, new[] { 1 }, new[] { 1 })]
        [InlineData(1, null, new[] { 1 }, new[] { 1 })]
        [InlineData(1, null, null, new[] { 1 })]
        [InlineData(1, null, null, null)]
        public async Task CantCreateOrder_WithNullRequiredParameters_(int guestId, int waiterId, int[] foodIds, int[] drinkIds)
        {
            // Arrange & Act & Assert

            // TODO: Add Asserts on Exception Messages

            await Assert.ThrowsAnyAsync<Exception>(async () =>
            {
                var createOrderDto = new CreateOrderDto(guestId, waiterId, foodIds.ToList(), drinkIds.ToList(), DateTime.Now, null);
                var getOrderDto = await _orderService.CreateOrder(createOrderDto);
            });
        }

        private async Task SetupCleanOrderService()
        {
            _restaurantDbContext =
            new InMemoryRestaurantDbContext()
            .Initialize();

            //await new BaseDataToRestaurantDbContext().AddAdditionalBaseDataToDbContext(_restaurantDbContext);

            var repo = new OrderRepository(_restaurantDbContext, new NullLogger<OrderRepository>());
            _orderService = new OrderService(repo, new NullLogger<OrderService>());
        }
    }
}