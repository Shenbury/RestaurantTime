using RestaurantTime.Shared.Models;

namespace RestaurantTime.Shared.Dtos.OrderDto.Extensions
{
    public static class OrderDtoExtensions
    {
       public static Order ToOrderModel(this CreateOrderDto dto)
        {
            var order = new Order
            {
                BeenServed = dto.BeenServed,
                EndTime = null,
                HasOrderedFood = false,
                InKitchen = false,
                PlatesTakenAway = false,
                StartTime = DateTime.Now,
                GuestId = dto.GuestId,
                WaiterId = dto.WaiterId,
                FoodOrders = dto.FoodIds.ToFoodOrders(),
                DrinkOrders = dto.DrinkIds.ToDrinkOrders()
            };

            return order;
        }

        public static (List<DrinkOrder>, List<FoodOrder>) ToDrinkOrdersAndFoodOrders(this GetOrderDto dto)
        {
            var drinkOrders = new List<DrinkOrder>();
            var foodOrders = new List<FoodOrder>();

            var orderId = dto.Id.HasValue ? (int)dto.Id : throw new NullReferenceException($"No ID was found for the order {dto.Id}");

            foreach (var drink in dto.Drinks)
            {
                drinkOrders.Add(
                new DrinkOrder
                {
                    DrinkId = drink.Id,
                    OrderId = orderId,
                    TimeOfOrder = DateTime.Now,
                });
            }

            foreach (var food in dto.Food)
            {
                foodOrders.Add(
                new FoodOrder
                {
                    FoodId = food.Id,
                    OrderId = orderId,
                    TimeOfOrder = DateTime.Now,
                });
            }

            return (drinkOrders, foodOrders);
        }

        public static GetOrderDto ToGetOrderDto(this Order entity)
        {
            var dto = new GetOrderDto
                (
                    entity.Id,
                    entity.GuestId,
                    entity.WaiterId,
                    entity.Foods.ToList(),
                    entity.Drinks.ToList(),
                    entity.StartTime,
                    entity.EndTime,
                    entity.HasOrderedFood,
                    entity.InKitchen,
                    entity.BeenServed,
                    entity.PlatesTakenAway
                );

            return dto;
        }

        private static List<FoodOrder> ToFoodOrders(this List<int> ints)
        {
            var foodOrders = ints.Select(id => new FoodOrder
            {
                FoodId = id
            }).ToList();

            return foodOrders;
        }

        private static List<DrinkOrder> ToDrinkOrders(this List<int> ints)
        {
            var drinkOrders = ints.Select(id => new DrinkOrder
            {
                DrinkId = id
            }).ToList();

            return drinkOrders;
        }
    }
}
