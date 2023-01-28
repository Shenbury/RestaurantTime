namespace RestaurantTime.Shared.Models
{
    public class Guest
    {
        public int Id { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
