using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Domain.Ordering.Entities;

namespace BlazingPizza.Application.Ordering.Mappers
{
    public static class PizzaSpecialMapper
    {
        public static PizzaSpecialDto ToPizzaSpecialDto(PizzaSpecial input)
        {
            return new PizzaSpecialDto
            {
                Id = input.Id,
                Name = input.Name,
                BasePrice = input.BasePrice,
                Description = input.Description,
                ImageUrl = input.ImageUrl
            };
        }
    }
}
