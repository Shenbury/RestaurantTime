using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Food
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string Name { get { return FoodsCurrentName(); } }
        [Required]
        public string UncookedName { get; set; }
        [Required]
        public string CookedName { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsCooked { get; set; } = false;
        public bool IsBurnt { get; set; } = false;
        public bool IsEdible { get; set; } = false;
        public bool IsServed { get; set; } = false;

        [Required]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public ICollection<Order> Orders { get; set; }

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
