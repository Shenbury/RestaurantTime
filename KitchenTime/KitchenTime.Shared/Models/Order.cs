using System.ComponentModel.DataAnnotations;

namespace RestaurantTime.Shared.Models
{
    public class Order
    {
        public Order(int id, bool inKitchen, bool beenServed, int platesTakenAway, DateTime startTime, DateTime endTime, bool hasOrderedFood, List<Food> orderedFoodItems, List<Drink> orderedDrinkItems, Guest guest, Waiter waiter)
        {
            Id = id;
            InKitchen = inKitchen;
            BeenServed = beenServed;
            PlatesTakenAway = platesTakenAway;
            StartTime = startTime;
            EndTime = endTime;
            HasOrderedFood = orderedFoodItems.Any();
            OrderedFoodItems = orderedFoodItems;
            OrderedDrinkItems = orderedDrinkItems;
            GuestId = guest.Id;
            Guest = guest;
            WaiterId = waiter.Id;
            Waiter = waiter;
        }

        [Key]
        public int Id { get; set; }
        public bool InKitchen { get; set; }
        public bool BeenServed { get; set; }
        public int PlatesTakenAway { get; set; }
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public bool HasOrderedFood { get; set; }

        public List<Food> OrderedFoodItems { get; set; }
        public List<Drink> OrderedDrinkItems { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public int WaiterId { get; set; }
        public Waiter Waiter { get; set; }
    }
}
