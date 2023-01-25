using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Recipe
    {
        public Recipe(int id, string name, string description, decimal successRate, int foodId)
        {
            Id = id;
            Name = name;
            Description = description;
            SuccessRate = successRate;
            FoodId = foodId;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SuccessRate { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }
    }
}
