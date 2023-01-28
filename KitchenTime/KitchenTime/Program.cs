using RestaurantTime.Database;
using RestaurantTime.Database.Services;
using RestaurantTime.Database.Services.Interfaces;
using RestaurantTime.Kitchen.Services.Services;
using RestaurantTime.Kitchen.Services.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

builder.Services.AddDbContext<RestaurantDbContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("PHConnection"), db => db.MigrationsAssembly("Project"));
    options.UseSqlServer(connection, b => b.MigrationsAssembly("Project.Api"))
                options.ConfigureWarnings(w => w.Log(RelationalEventId.MultipleCollectionIncludeWarning));
#if DEBUG
    options.EnableSensitiveDataLogging();
#endif
});

builder.Services.AddDbContext<ReadOnlyDatabaseContext>(options =>
{
    options.UseSqlServer(Configuration.GetConnectionString("PHConnection"));
    options.ConfigureWarnings(w => w.Log(RelationalEventId.MultipleCollectionIncludeWarning));
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }