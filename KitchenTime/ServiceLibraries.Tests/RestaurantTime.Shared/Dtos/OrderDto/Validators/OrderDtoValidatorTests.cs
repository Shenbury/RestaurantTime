using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.Shared.Dtos.OrderDto.Validators;
using RestaurantTime.Shared.Models;

namespace SharedLibraries.Tests.RestaurantTime.Shared.Dtos.OrderDto.Validators
{
    public class OrderDtoValidatorTests
    {
        // TODO: Add Asserts on Exception Messages

        [Fact]
        public void CanValidate_WithCreateOrderDto()
        {
            var dto = new CreateOrderDto(1 , 1, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null);

            dto.Validate();
        }

        [Fact]
        public void CannotValidate_WithCreateOrderDto_WhenNoFoodOrDrinks()
        {
            var dto = new CreateOrderDto(1, 1, new List<int>(), new List<int>(), DateTime.Now, null);

            Assert.Throws<ArgumentException>(() => dto.Validate());
        }

        [Fact]
        public void CannotValidate_WithCreateOrderDto_WhenGuestIdIs0()
        {
            var dto = new CreateOrderDto(0, 1, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null);

            Assert.Throws<NullReferenceException>(() => dto.Validate());
        }

        [Fact]
        public void CannotValidate_WithCreateOrderDto_WhenWaiterIdIs0()
        {
            var dto = new CreateOrderDto(1, 0, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null);

            Assert.Throws<NullReferenceException>(() => dto.Validate());
        }

        [Fact]
        public void CanValidate_WithGetOrderDto()
        {
            var dto = new GetOrderDto(1, 1, 1, new List<Food> { new Food { Id = 1} }, new List<Drink> { new Drink { Id = 1} }, DateTime.Now, null);

            dto.Validate();
        }

        [Fact]
        public void CannotValidate_WithGetOrderDto_WhenIdIs0()
        {
            var dto = new GetOrderDto(0, 1, 1, new List<Food>(), new List<Drink>(), DateTime.Now, null);

            Assert.Throws<NullReferenceException>(() => dto.Validate());
        }

        [Fact]
        public void CannotValidate_WithGetOrderDto_WhenGuestIdIs0()
        {
            var dto = new GetOrderDto(1, 0, 1, new List<Food>(), new List<Drink>(), DateTime.Now, null);

            Assert.Throws<NullReferenceException>(() => dto.Validate());
        }

        [Fact]
        public void CannotValidate_WithGetOrderDto_WhenWaiterIdIs0()
        {
            var dto = new GetOrderDto(1, 1, 0, new List<Food>(), new List<Drink>(), DateTime.Now, null);

            Assert.Throws<NullReferenceException>(() => dto.Validate());
        }

        [Fact]
        public void CannotValidate_WithGetOrderDto_WhenNoFoodOrDrinks()
        {
            var dto = new GetOrderDto(1, 1, 1, new List<Food>(), new List<Drink>(), DateTime.Now, null);

            Assert.Throws<ArgumentException>(() => dto.Validate());
        }
    }
}
