using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
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

AddOrderServices(builder);
AddDbContext(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddDbContext(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<RestaurantDbContext>(options =>
    {
        var connection = builder.Configuration.GetConnectionString("RestaurantSqlConnection");
        if (connection == null)
        {
            throw new NotImplementedException("DbConnection string was not found");
        }

        options.UseSqlServer(connection, b => b.MigrationsAssembly("RestaurantTime.Database"));
        options.ConfigureWarnings(w => w.Log(RelationalEventId.MultipleCollectionIncludeWarning));

#if DEBUG
        options.EnableSensitiveDataLogging();
#endif

    });
}

static void AddOrderServices(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IOrderService, OrderService>();
    builder.Services.AddTransient<IOrderRepository, OrderRepository>();
}

public partial class Program { }