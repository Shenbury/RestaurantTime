using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Food
    {
        private string UncookedName { get; set; }
        private string CookedName { get; set; }

        public Food(int id, string uncookedName, string cookedName, string description , bool isCooked = false, bool isBurnt = false, bool isEdible = false, bool isServed = false)
        {
            Id = id;
            UncookedName = uncookedName;
            CookedName = cookedName;
            Name = isCooked ? cookedName : uncookedName;
            Description = description;
            IsCooked = isCooked;
            IsBurnt = isBurnt;
            IsEdible = isEdible;
            IsServed = isServed;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsCooked { get; set; } = false;
        public bool IsBurnt { get; set; } = false;
        public bool IsEdible { get; set; } = false;
        public bool IsServed { get; set; } = false;

        public Food Cooking(Food food)
        {
            food.IsCooked = true;
            food.Name = CookedName;

            if (IsCooked)
            {
                IsBurnt = true;
                IsEdible = true;
            }

            return food;
        }
    }
}
