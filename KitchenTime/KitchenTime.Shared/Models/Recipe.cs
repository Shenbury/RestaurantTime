using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SuccessRate { get; set; }

        public ICollection<Chef> ChefsKnownBy { get; set; }
        public List<ChefRecipe> ChefRecipes { get; set; }
    }
}
