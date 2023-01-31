using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Recipe
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal SuccessRate { get; set; }

        public ICollection<Chef> ChefsKnownBy { get; set; }
        public List<ChefRecipe> ChefRecipes { get; set; }
    }
}
