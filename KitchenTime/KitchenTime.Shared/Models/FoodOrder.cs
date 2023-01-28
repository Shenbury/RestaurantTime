namespace RestaurantTime.Shared.Models
{
    public class FoodOrder
    {
        public DateTime TimeOfOrder { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
