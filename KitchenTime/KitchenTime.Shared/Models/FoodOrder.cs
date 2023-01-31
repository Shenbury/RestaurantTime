using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class FoodOrder
    {
        [Required]
        public DateTime TimeOfOrder { get; set; }

        [Required]
        public int FoodId { get; set; }
        public Food Food { get; set; }

        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
