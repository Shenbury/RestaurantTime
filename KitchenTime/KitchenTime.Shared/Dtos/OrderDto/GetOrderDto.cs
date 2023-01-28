namespace RestaurantTime.Shared.Dtos.OrderDto
{
    public class GetOrderDto
    {
        public GetOrderDto(int id, int guestId, int waiterId, List<int> foodIds, List<int> drinkIds, DateTime startTime, DateTime endTime, bool hasOrderedFood, bool inKitchen, bool beenServed, bool platesTakenAway)
        {
            Id = id;
            GuestId = guestId;
            WaiterId = waiterId;
            FoodIds = foodIds;
            DrinkIds = drinkIds;
            StartTime = startTime;
            EndTime = endTime;
            HasOrderedFood = hasOrderedFood;
            InKitchen = inKitchen;
            BeenServed = beenServed;
            PlatesTakenAway = platesTakenAway;
        }

        public int Id { get; set; }
        public int GuestId { get; set; }
        public int WaiterId { get; set; }
        public List<int> FoodIds { get; set; }
        public List<int> DrinkIds { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool HasOrderedFood { get; set; }
        public bool InKitchen { get; set; }
        public bool BeenServed { get; set; }
        public bool PlatesTakenAway { get; set; }
    }
}
