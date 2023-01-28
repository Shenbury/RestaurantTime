using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public string Name { get { return FoodsCurrentName(); } }
        public string UncookedName { get; set; }
        public string CookedName { get; set; }
        public string Description { get; set; }
        public bool IsCooked { get; set; } = false;
        public bool IsBurnt { get; set; } = false;
        public bool IsEdible { get; set; } = false;
        public bool IsServed { get; set; } = false;

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        private string FoodsCurrentName()
        {
            if (IsCooked)
            {
                if (IsBurnt)
                {
                    return "Burnt " + CookedName;
                }

                return CookedName;
            }

            return UncookedName;
        }
    }
}
