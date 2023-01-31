using RestaurantTime.Database;

namespace RestaurantTime.TestingLibraries.MockData
{
    public class BaseDataToRestaurantDbContext
    {
        public async Task AddBaseDataToDbContext(RestaurantDbContext dbContext)
        {
            await dbContext.Waiters.AddAsync(BaseData.BaseWaiter);
            await dbContext.SaveChangesAsync();

            await dbContext.Recipes.AddAsync(BaseData.BaseRecipe);
            await dbContext.SaveChangesAsync();

            await dbContext.Chefs.AddAsync(BaseData.BaseChef);
            await dbContext.SaveChangesAsync();

            await dbContext.Guests.AddAsync(BaseData.BaseGuest);
            await dbContext.SaveChangesAsync();

            await dbContext.Drinks.AddAsync(BaseData.BaseDrink);
            await dbContext.SaveChangesAsync();

            await dbContext.Foods.AddAsync(BaseData.BaseFood);
            await dbContext.SaveChangesAsync();

            await dbContext.Orders.AddAsync(BaseData.BaseOrder);
            await dbContext.SaveChangesAsync();
        }
    }
}
