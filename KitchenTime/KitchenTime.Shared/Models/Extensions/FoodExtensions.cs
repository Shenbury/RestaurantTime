namespace RestaurantTime.Shared.Models.Extensions
{
    public static class FoodExtensions
    {
        public static Food Cook(this Food food)
        {
            food = food.Cooking(food);

            return food;
        }
    }
}
