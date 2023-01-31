using Microsoft.EntityFrameworkCore;
using RestaurantTime.Database;

namespace RestaurantTime.TestingLibraries.UnitTestFramework
{
    public class InMemoryRestaurantDbContext
    {
        public RestaurantDbContext Initialize() 
        {
            DbContextOptions<RestaurantDbContext> options = new DbContextOptionsBuilder<RestaurantDbContext>()
            .UseInMemoryDatabase(databaseName: "RestaurantTime")
            .Options;

            var context = new RestaurantDbContext(options);

            return context;
        }
    }
}
