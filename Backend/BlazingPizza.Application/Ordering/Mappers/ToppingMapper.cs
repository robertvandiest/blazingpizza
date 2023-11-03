using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Domain.Ordering.Entities;

namespace BlazingPizza.Application.Ordering.Mappers
{
    internal static class ToppingMapper
    {
        public static Topping ToToppingEntity(ToppingDto input)
        {
            return new Topping
            {
                Id = input.Id
            };
        }

        public static ToppingDto ToToppingDto(Topping input)
        {
            return new ToppingDto
            {
                Id = input.Id,
                Name = input.Name,
                Price = input.Price
            };
        }
    }
}
