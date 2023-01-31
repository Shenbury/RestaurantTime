using RestaurantTime.Shared.Models;

namespace RestaurantTime.TestingLibraries.MockData
{
    public static class BaseData
    {
        public static Waiter BaseWaiter = new Waiter { Id = 2, Name = "The Don" };

        public static Recipe BaseRecipe = new Recipe { Id = 2, Name = "Beef Wellington", Description = "Beef in Pastry", SuccessRate = 0.9m };

        public static Chef BaseChef = new Chef { Id = 2, Name = "Gordon Ramsay", KnownRecipes = new List<Recipe> { BaseRecipe }, IsWorkingToday = true };

        public static Guest BaseGuest = new Guest { Id = 2 };

        public static Food BaseFood = new Food { Id = 2, CookedName = "Beef Wellington", UncookedName = "Beef and Dough", RecipeId = 1 };

        public static Drink BaseDrink = new Drink { Id = 2, Name = "Beer", Description = "A golden lite beer" };

        public static Order BaseOrder = new Order { Id = 2, StartTime = DateTime.Now, GuestId = 1 , WaiterId = 1, Drinks = new List<Drink> { BaseDrink }, Foods = new List<Food> { BaseFood } };
    }
}
