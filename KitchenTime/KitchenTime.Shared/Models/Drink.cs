namespace RestaurantTime.Shared.Models
{
    public class Drink
    {
        public Drink(int id, string name, string description, bool isServed = false)
        {
            Id = id;
            Name = name;
            Description = description;
            IsServed = isServed;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsServed { get; set; } = false;

        public ICollection<Order> Orders { get; set; }
        public List<DrinkOrder> DrinkOrders { get; set; }
    }
}
