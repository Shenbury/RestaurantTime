using Microsoft.EntityFrameworkCore;
using RestaurantTime.Shared.Models;

namespace RestaurantTime.Database
{

    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {
            Database.EnsureCreated();
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
            modelBuilder.Entity<Recipe>()
            .HasData(new Recipe
            {
                Id = 1,
                Description = "Some Jerkin Chicken",
                SuccessRate = 0.9m,
                Name = "Jerk Chicken",
            });

            modelBuilder.Entity<Waiter>()
            .HasData(new Waiter
            {
                Id = 1,
                Name = "Michael Jackson",
                CanCarryPlates = false,
                CanTakeOrders = true,
            });

            modelBuilder.Entity<Drink>()
            .HasData(new Drink
            {
                Id = 1,
                Description = "Stuff with Tomato Juice",
                Name = "Bloody Mary",

            });

            modelBuilder.Entity<Guest>()
            .HasData(new Guest
            {
            Id = 1,
            });

            modelBuilder.Entity<Chef>()
                .HasMany(c => c.KnownRecipes)
                .WithMany(r => r.ChefsKnownBy)
                .UsingEntity<ChefRecipe>(
                j =>
                {
                    j.Property(pt => pt.DateChefLearnedRecipe).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.ChefId, t.RecipeId });
                    j.HasData(
                    new ChefRecipe
                    {
                        ChefId = 1,
                        RecipeId = 1,
                        DateChefLearnedRecipe = DateTime.Now
                    });
                })
                .HasData(
                    new Chef
                    {
                        Id = 1,
                        IsWorkingToday = true,
                        Name = "Bob Marley",
                    });

            modelBuilder.Entity<Food>()
                .HasMany(c => c.Orders)
                .WithMany(r => r.OrderedFoodItems)
                .UsingEntity<FoodOrder>(
                j =>
                {
                    j.Property(pt => pt.TimeOfOrder).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.FoodId, t.OrderId });
                    j.HasData
                    (
                            new FoodOrder
                            {
                                FoodId = 1,
                                OrderId = 1,
                                TimeOfOrder = DateTime.Now
                            });
                })
                .HasData
                    (
                new Food
                {
                    Id = 1,
                    CookedName = "Jerk Chicken",
                    Description = "Top Notch Jerk Chicken",
                    IsBurnt = false,
                    IsCooked = false,
                    IsEdible = false,
                    IsServed = false,
                    RecipeId = 1,
                    UncookedName = "Raw Chicken and Sauce"
                });

            modelBuilder.Entity<Drink>()
                .HasMany(c => c.Orders)
                .WithMany(r => r.OrderedDrinkItems)
                .UsingEntity<DrinkOrder>(
                j =>
                {
                    j.Property(pt => pt.TimeOfOrder).HasDefaultValueSql("CURRENT_TIMESTAMP");
                    j.HasKey(t => new { t.DrinkId, t.OrderId });
                    j.HasData
                    (
                    new DrinkOrder
                    {
                        DrinkId = 1,
                        OrderId = 1,
                        TimeOfOrder = DateTime.Now
                    });
                });

            modelBuilder.Entity<Order>()
            .HasData(new Order
            {
                Id = 1,
                BeenServed = false,
                StartTime = DateTime.Now,
                EndTime = null,
                GuestId = 1,
                HasOrderedFood = true,
                InKitchen = false,
                PlatesTakenAway = false,
                WaiterId = 1,
            });
        }
    }
}
