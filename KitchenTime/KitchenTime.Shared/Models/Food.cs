using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Food
    {
        public string UncookedName { get; set; }
        public string CookedName { get; set; }

        public Food(int id, string uncookedName, string cookedName, string description , bool isCooked = false, bool isBurnt = false, bool isEdible = false, bool isServed = false)
        {
            Id = id;
            UncookedName = uncookedName;
            CookedName = cookedName;
            Description = description;
            IsCooked = isCooked;
            IsBurnt = isBurnt;
            IsEdible = isEdible;
            IsServed = isServed;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get { return IsCooked ? CookedName : UncookedName; } }
        public string Description { get; set; }
        public bool IsCooked { get; set; } = false;
        public bool IsBurnt { get; set; } = false;
        public bool IsEdible { get; set; } = false;
        public bool IsServed { get; set; } = false;

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public Food Cooking(Food food)
        {
            food.IsCooked = true;
            food.Name = CookedName;

            if (IsCooked)
            {
                IsBurnt = true;
                food.Name = "Burnt " + CookedName;
                IsEdible = true;
            }

            return food;
        }
    }
}
