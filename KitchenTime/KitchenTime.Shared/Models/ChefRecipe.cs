using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class ChefRecipe
    {
        [Required]
        public DateTime DateChefLearnedRecipe { get; set; }

        [Required]
        public int ChefId { get; set; }
        public Chef Chef { get; set; }

        [Required]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } 
    }
}
