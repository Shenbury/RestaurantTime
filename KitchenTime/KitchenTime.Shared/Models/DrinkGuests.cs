namespace RestaurantTime.Shared.Models
{
    public class DrinkGuests
    {
        public bool IsServed { get; set; } = false;

        public DateTime TimeOfOrder { get; set; } = DateTime.Now;
    }
}
