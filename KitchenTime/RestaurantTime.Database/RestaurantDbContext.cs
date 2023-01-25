using Microsoft.EntityFrameworkCore;
using RestaurantTime.Shared.Models;

namespace RestaurantTime.Database
{

    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
    }
}
