using Microsoft.VisualStudio.TestPlatform.TestHost;
using RestaurantTime.Shared.Dtos.OrderDto;
using RestaurantTime.TestingLibraries.IntegrationTestFramework;
using System.Text;

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

        [Theory]
        [InlineData("/Kitchen/CreateOrder")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var newOrder = new CreateOrderDto(1, 1, new List<int> { 1 }, new List<int> { 1 }, DateTime.Now, null, true, false, false, false);
            var newOrderContent = new StringContent(newOrder.ToString(), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/Kitchen/CreateOrder", newOrderContent);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299

            Assert.NotNull(response.Content.ReadAsStringAsync());
        }
    }
}