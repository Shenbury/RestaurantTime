namespace RestaurantTime.Shared.Models
{
    public class Waiter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool CanCarryPlates { get; set; }
        public bool CanTakeOrders { get; set; }

        public ICollection<Order> Orders { get;set; }
        public ICollection<Guest> Guests { get; set; }
    }
}
