using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Shared.Dtos.OrderDto.Extensions;
using RestaurantTime.Shared.Models;

namespace SharedLibraries.Tests.RestaurantTime.Shared.Dtos.OrderDto.Extensions
{
    public class OrderDtoExtensionTests
    {
        // TODO: Negative Tests

        [Fact]
        public void CanToOrderModel_WithCreateOrderDto()
        {
            // Arrange
            var dto = new CreateOrderDto(1, 1, new List<int>(1), new List<int>(1), DateTime.Now, null) { };

            // Act
            var result = dto.ToOrderModel();

            // Assert
            Assert.Equal(dto.GuestId, result.GuestId);
            Assert.Equal(dto.WaiterId, result.WaiterId);
            Assert.Equal(dto.FoodIds, result.FoodOrders.Select(f => f.FoodId).ToList());
            Assert.Equal(dto.DrinkIds, result.DrinkOrders.Select(f => f.DrinkId).ToList());
        }

        [Fact]
        public void CanToDrinkOrdersAndFoodOrders_WithGetOrderDto()
        {
            // Arrange
            var dto = new GetOrderDto(1, 1, 1, 

                new List<Food>() { 
                    new Food { Id = 2, CookedName = "Toast", UncookedName = "Bread", Description = "Banging Toast",} }, 

                new List<Drink> { 
                    new Drink { Id = 2, Name = "Cola", Description = "A sugary mess" } }, 

                DateTime.Now, null) { };

            // Act
            var result = dto.ToDrinkOrdersAndFoodOrders();

            // Assert
            Assert.Equal(dto.Food.Select(f => f.Id).First(), result.Item2.First().FoodId);
            Assert.Equal(dto.Drinks.Select(f => f.Id).First(), result.Item1.First().DrinkId);
        }

        [Fact]
        public void CanToGetOrderDto_WithOrder()
        {
            // Arrange
            var dto = new Order
            {
                Id = 1,
                GuestId = 1,
                WaiterId = 1,
                Foods = new List<Food>() {
                    new Food { Id = 2, CookedName = "Toast", UncookedName = "Bread", Description = "Banging Toast",} },
                Drinks = new List<Drink> {
                    new Drink { Id = 2, Name = "Cola", Description = "A sugary mess" } },
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                HasOrderedFood = false,
                InKitchen = false,
                BeenServed = false,
                PlatesTakenAway = false
            };

            // Act
            var result = dto.ToGetOrderDto();

            // Assert
            Assert.Equal(dto.Id, result.Id);
            Assert.Equal(dto.GuestId, result.GuestId);
            Assert.Equal(dto.WaiterId, result.WaiterId);
            Assert.Equal(dto.Foods.Select(f => f.Id).First(), result.Food.First().Id);
            Assert.Equal(dto.Drinks.Select(f => f.Id).First(), result.Drinks.First().Id);
            Assert.Equal(dto.StartTime, result.StartTime);
            Assert.Equal(dto.EndTime, result.EndTime);
            Assert.Equal(dto.HasOrderedFood, result.HasOrderedFood);
            Assert.Equal(dto.InKitchen, result.InKitchen);
            Assert.Equal(dto.BeenServed, result.BeenServed);
            Assert.Equal(dto.PlatesTakenAway, result.PlatesTakenAway);
        }

        [Fact]
        public void CanToFoodOrders_WithInts()
        {
            // Arrange
            var dto = new List<int> { 1 };

            // Act
            var result = dto.ToFoodOrders();

            // Assert
            Assert.Equal(dto.First(), result.First().FoodId);
        }

        [Fact]
        public void CanToDrinkOrders_WithInts()
        {
            // Arrange
            var dto = new List<int> { 1 };

            // Act
            var result = dto.ToDrinkOrders();

            // Assert
            Assert.Equal(dto.First(), result.First().DrinkId);
        }
    }
}