using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Guest
    {
        [Required]
        public int Id { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
