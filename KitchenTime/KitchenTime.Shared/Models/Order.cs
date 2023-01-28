using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Order
    {
        [Key]
        public int? Id { get; set; }
        public bool InKitchen { get; set; }
        public bool BeenServed { get; set; }
        public bool PlatesTakenAway { get; set; }
        public DateTime StartTime {get; set;}
        public DateTime? EndTime {get; set;}
        public bool HasOrderedFood { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public int WaiterId { get; set; }
        public Waiter Waiter { get; set; }

        public ICollection<Food> OrderedFoodItems { get; set; }
        public List<FoodOrder> FoodOrders { get; set; }

        public ICollection<Drink> OrderedDrinkItems { get; set; }
        public List<DrinkOrder> DrinkOrders { get; set; }
    }
}
