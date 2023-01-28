using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Shared.Dtos.OrderDto;
using System.Reflection.Metadata;

namespace RestaurantTime.Database.Services
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<GetOrderDto> Create(CreateOrderDto dto)
        {
            using (var db = new RestaurantDbContext())
            {
                // Create and save a new Blog
                Console.Write("Enter a name for a new Blog: ");
                var name = Console.ReadLine();

                var blog = new Blog { Name = name };
                db.Blogs.Add(blog);
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Blogs
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            }
        }
    }
}
