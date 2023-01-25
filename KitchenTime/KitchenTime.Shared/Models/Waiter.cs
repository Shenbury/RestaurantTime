namespace RestaurantTime.Shared.Models
{
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanCarryPlates { get; set; }
        public bool CanTakeOrders { get; set; }
        public bool IsServed { get; set; }
    }
}
