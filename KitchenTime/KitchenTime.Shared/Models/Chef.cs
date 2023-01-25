using RestaurantTime.Shared.Models.Extensions;

namespace RestaurantTime.Shared.Models
{
    public class Chef
    {
        public Chef(int id, string name, List<Recipe> knownRecipes, bool isWorkingToday)
        {
            Id = id;
            Name = name;
            KnownRecipes = knownRecipes;
            IsWorkingToday = isWorkingToday;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsWorkingToday { get; set; }
        public List<Recipe> KnownRecipes { get; set; }

        public Food CookFood(Food food)
        {
            food = food.Cook();

            return food;
        }
    }
}
