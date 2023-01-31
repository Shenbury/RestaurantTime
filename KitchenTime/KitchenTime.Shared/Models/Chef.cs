using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Chef
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsWorkingToday { get; set; } = false;

        public ICollection<Recipe> KnownRecipes { get; set; }
    }
}
