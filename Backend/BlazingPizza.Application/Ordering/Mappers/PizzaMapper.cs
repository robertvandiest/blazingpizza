using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Domain.Ordering.Entities;

namespace BlazingPizza.Application.Ordering.Mappers
{
    internal static class PizzaMapper
    {
        public static Pizza ToPizzaEntity(PizzaDto input)
        {
            return new Pizza
            {
                SpecialId = input.Special.Id,
                Special = new PizzaSpecial
                {
                    Id = input.Special.Id, 
                    BasePrice = input.Special.BasePrice, 
                    Description = input.Special.Description, 
                    ImageUrl = input.Special.ImageUrl, 
                    Name = input.Special.Name,
                },
                Size = input.Size, 
                Toppings = input.Toppings.Select(ToppingMapper.ToToppingEntity).ToArray()
            };
        }

        public static PizzaDto ToPizzaDto(Pizza input)
        {
            return new PizzaDto
            {
                Size = input.Size,
                Special = new PizzaSpecialDto
                {
                    Id = input.Special.Id,
                    BasePrice = input.Special.BasePrice,
                    Description = input.Special.Description,
                    ImageUrl = input.Special.ImageUrl,
                    Name = input.Special.Name
                },
                Toppings = input.Toppings.Select(ToppingMapper.ToToppingDto).ToArray()
            };
        }
    }
}
