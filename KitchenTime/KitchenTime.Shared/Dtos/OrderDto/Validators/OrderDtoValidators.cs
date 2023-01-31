namespace RestaurantTime.Shared.Dtos.OrderDto.Validators
{
    public static class OrderDtoValidators
    {
        public static void Validate(this CreateOrderDto dto)
        {
            if (dto.GuestId == 0)
            {
                throw new NullReferenceException(nameof(dto.GuestId));
            }

            if (dto.WaiterId == 0)
            {
                throw new NullReferenceException(nameof(dto.WaiterId));
            }

            var NoFood = !dto.FoodIds.Any();
            var NoDrinks = !dto.DrinkIds.Any();

            if (NoFood && NoDrinks)
            {
                throw new ArgumentException($"No food or drink was found in the order");
            }
        }

        public static void Validate(this GetOrderDto dto)
        {
            if (dto.Id == 0)
            {
                throw new NullReferenceException(nameof(dto.Id));
            }

            if (dto.GuestId == 0)
            {
                throw new NullReferenceException(nameof(dto.GuestId));
            }

            if (dto.WaiterId == 0)
            {
                throw new NullReferenceException(nameof(dto.WaiterId));
            }

            var NoFood = !dto.Food.Any();
            var NoDrinks = !dto.Drinks.Any();

            if (NoFood && NoDrinks)
            {
                throw new ArgumentException($"No food or drink was found in the order");
            }
        }
    }
}
