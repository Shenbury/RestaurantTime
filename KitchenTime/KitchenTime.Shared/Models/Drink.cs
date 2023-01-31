using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Drink
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }
        public List<DrinkOrder> DrinkOrders { get; set; }
    }
}
