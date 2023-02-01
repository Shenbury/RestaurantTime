using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.TestingLibraries.IntegrationTestFramework;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace RestaurantTime.Api.ControllerTests
{
    public class FrontOfHouseControllerTests
        : IClassFixture<RestaurantTimeApplicationFactory<Program>>
    {
        private readonly RestaurantTimeApplicationFactory<Program> _factory;

        public FrontOfHouseControllerTests(RestaurantTimeApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Can_CreateOrder_With_OrderDetails()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newOrder = new CreateOrderDto(1, 1, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null, true, false, false, false);
            var newOrderContent = new StringContent(JsonSerializer.Serialize(newOrder), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("FrontOfHouse/CreateOrder", newOrderContent);

            // Assert
            var responseString = response.Content.ReadAsStringAsync();

            response.EnsureSuccessStatusCode(); // Status Code 200-299

            var json = await response.Content.ReadFromJsonAsync<GetOrderDto>();

            Assert.Equal(newOrder.GuestId, json.GuestId);
            Assert.Equal(newOrder.WaiterId, json.WaiterId);
            Assert.Equal(newOrder.FoodIds.First(), json.Food.Select(f => f.Id).First());
            Assert.Equal(newOrder.DrinkIds.First(), json.Drinks.Select(f => f.Id).First());
            Assert.Equal(newOrder.InKitchen, json.InKitchen);
            Assert.Equal(newOrder.BeenServed, json.BeenServed);
            Assert.Equal(newOrder.PlatesTakenAway, json.PlatesTakenAway);
        }
    }
}