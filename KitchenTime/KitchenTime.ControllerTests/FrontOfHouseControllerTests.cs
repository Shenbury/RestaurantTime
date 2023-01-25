using Microsoft.VisualStudio.TestPlatform.TestHost;
using RestaurantTime.TestingLibraries.IntegrationTestFramework;

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
        [InlineData("/")]
        [InlineData("/Index")]
        [InlineData("/About")]
        [InlineData("/Privacy")]
        [InlineData("/Contact")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("text/html; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}