using RestaurantTime.Database;

namespace RestaurantTime.TestingLibraries.MockData
{
    public class BaseDataToRestaurantDbContext
    {
        public async Task AddAdditionalBaseDataToDbContext(RestaurantDbContext dbContext)
        {
            await dbContext.Waiters.AddAsync(BaseData.BaseWaiter);
            await dbContext.Recipes.AddAsync(BaseData.BaseRecipe);
            await dbContext.Chefs.AddAsync(BaseData.BaseChef);
            await dbContext.Guests.AddAsync(BaseData.BaseGuest);
            await dbContext.Drinks.AddAsync(BaseData.BaseDrink);
            await dbContext.Foods.AddAsync(BaseData.BaseFood);
            await dbContext.Orders.AddAsync(BaseData.BaseOrder);

            await dbContext.SaveChangesAsync();
        }
    }
}
