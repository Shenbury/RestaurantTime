namespace RestaurantTime.Shared.Models
{
    public class Drink
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Order> Orders { get; set; }
        public List<DrinkOrder> DrinkOrders { get; set; }
    }
}
