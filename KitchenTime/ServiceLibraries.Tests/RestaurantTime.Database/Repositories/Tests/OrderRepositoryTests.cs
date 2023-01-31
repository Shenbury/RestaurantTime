using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using RestaurantTime.Database;
using RestaurantTime.Database.Repositories;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.TestingLibraries.UnitTestFramework;

namespace SharedLibraries.Tests.RestaurantTime.Database.Repositories.Tests
{
    public class OrderRepositoryTests
    {
        private RestaurantDbContext _restaurantDbContext;
        private OrderRepository _orderRepository;

        public OrderRepositoryTests()
        {
            Task.Run(() => SetupCleanOrderRepository()).Wait();
        }

        [Fact]
        public async void CanCreate_WithCreateOrderDto()
        {
            // Arrange
            var dto = new CreateOrderDto(1, 1, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null) { };

            // Act
            var result = await _orderRepository.Create(dto);

            // Assert
            var dbOrder = await _restaurantDbContext.Orders.SingleAsync(o => o.Id == result.Id);

            Assert.Equal(dto.GuestId, dbOrder.GuestId);
            Assert.Equal(dto.WaiterId, dbOrder.WaiterId);
            Assert.Equal(dto.FoodIds, dbOrder.FoodOrders.Select(f => f.FoodId).ToList());
            Assert.Equal(dto.DrinkIds, dbOrder.DrinkOrders.Select(f => f.DrinkId).ToList());
        }

        // TODO: Negative tests


        private async Task SetupCleanOrderRepository()
        {
            _restaurantDbContext =
            new InMemoryRestaurantDbContext()
            .Initialize();

            //await new BaseDataToRestaurantDbContext().AddAdditionalBaseDataToDbContext(_restaurantDbContext);

            _orderRepository = new OrderRepository(_restaurantDbContext, new NullLogger<OrderRepository>());
        }
    }
}
