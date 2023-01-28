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
            var orderId = entity.Id.HasValue ? entity.Id : throw new NullReferenceException($"No ID was found for the order {entity.Id}");

            var dto = new GetOrderDto
                (
                    orderId,
                    entity.GuestId,
                    entity.WaiterId,
                    entity.OrderedFoodItems.ToList(),
                    entity.OrderedDrinkItems.ToList(),
                    entity.StartTime,
                    entity.EndTime,
                    entity.HasOrderedFood,
                    entity.InKitchen,
                    entity.BeenServed,
                    entity.PlatesTakenAway
                );

            return dto;
        }
    }
}
