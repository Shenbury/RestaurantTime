using Microsoft.EntityFrameworkCore;
using RestaurantTime.Shared.Models;

namespace RestaurantTime.Database
{

    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Waiter> Waiters { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Guest> Guests { get; set; }
    }
}
