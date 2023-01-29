using RestaurantTime.TestingLibraries.IntegrationTestFramework;

namespace RestaurantTime.Api.ControllerTests
{
    public class KitchenControllerTests
         : IClassFixture<RestaurantTimeApplicationFactory<Program>>
    {
        private readonly RestaurantTimeApplicationFactory<Program> _factory;

        public KitchenControllerTests(RestaurantTimeApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
    }
}
