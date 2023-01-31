using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public bool InKitchen { get; set; } = false;
        public bool BeenServed { get; set; } = false;
        public bool PlatesTakenAway { get; set; } = false;

        [Required]
        public DateTime StartTime {get; set;}
        public DateTime? EndTime {get; set;}
        public bool HasOrderedFood { get; set; } = false;

        [Required]
        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        [Required]
        public int WaiterId { get; set; }
        public Waiter Waiter { get; set; }

        public ICollection<Food> Foods { get; set; }
        public List<FoodOrder> FoodOrders { get; set; }

        public ICollection<Drink> Drinks { get; set; }
        public List<DrinkOrder> DrinkOrders { get; set; }
    }
}
