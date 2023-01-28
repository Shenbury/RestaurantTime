namespace RestaurantTime.Shared.Models
{
    public class Chef
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool IsWorkingToday { get; set; } = false;

        public ICollection<Recipe> KnownRecipes { get; set; }
    }
}
