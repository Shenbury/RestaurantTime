namespace RestaurantTime.Shared.Models
{
    public class DrinkOrder
    {
        public DateTime TimeOfOrder { get; set; }

        public int DrinkId { get; set; }
        public Drink Drink { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
