using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Waiter
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public bool CanCarryPlates { get; set; } = false;
        public bool CanTakeOrders { get; set; } = false;

        public ICollection<Order> Orders { get;set; }
        public ICollection<Guest> Guests { get; set; }
    }
}
