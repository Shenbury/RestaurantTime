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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chef>()
                .HasMany(c => c.KnownRecipes)
                .WithMany(r => r.ChefsKnownBy)
                .UsingEntity<ChefRecipe>(
                j =>
                {
                    j.Property(pt => pt.DateChefLearnedRecipe).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.ChefId, t.RecipeId });
                });

            modelBuilder.Entity<Food>()
                .HasMany(c => c.Orders)
                .WithMany(r => r.OrderedFoodItems)
                .UsingEntity<FoodOrder>(
                j =>
                {
                    j.Property(pt => pt.TimeOfOrder).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.FoodId, t.OrderId });
                }); ;

            modelBuilder.Entity<Drink>()
                .HasMany(c => c.Orders)
                .WithMany(r => r.OrderedDrinkItems)
                .UsingEntity<DrinkOrder>(
                j =>
                {
                    j.Property(pt => pt.TimeOfOrder).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.DrinkId, t.OrderId });
                });
        }
    }
}
