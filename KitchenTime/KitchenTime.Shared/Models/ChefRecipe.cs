namespace RestaurantTime.Shared.Models
{
    public class ChefRecipe
    {
        public DateTime DateChefLearnedRecipe { get; set; }

        public int ChefId { get; set; }
        public Chef Chef { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } 
    }
}
