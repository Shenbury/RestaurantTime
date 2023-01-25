namespace RestaurantTime.Shared.Dtos
{
    public class CreateOrderDto
    {
        public int GuestId { get; set; }
        public int WaiterId { get; set; }
        public List<int> FoodIds { get; set; }
        public List<int> DrinkIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool HasOrderedFood { get; set; }
        public bool InKitchen { get; set; } = false;
        public bool BeenServed { get; set; } = false;
        public bool PlatesTakenAway { get; set; } = false;
    }
}
