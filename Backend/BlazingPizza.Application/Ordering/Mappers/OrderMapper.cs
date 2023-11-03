using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Domain.Ordering.Events;

namespace BlazingPizza.Application.Ordering.Mappers
{
    public static class OrderMapper
    {
        public static Order ToOrderEntity(OrderDto input)
        {
            return new Order
            {
                CreatedTime = input.CreatedTime,
                DeliveryAddress = new Address
                {
                    City = input.DeliveryAddress.City,
                    PostalCode = input.DeliveryAddress.PostalCode,
                    Line1 = input.DeliveryAddress.Line1,
                    Line2 = input.DeliveryAddress.Line2,
                    Name = input.DeliveryAddress.Name,
                    Region = input.DeliveryAddress.Region
                },
                Pizzas = input.Pizzas.Select(PizzaMapper.ToPizzaEntity).ToArray(),
                UserId = "gu"
            };
        }

        public static OrderSummaryDto ToOrderSummaryDto(Order input)
        {
            return new OrderSummaryDto
            {
                CreatedTime = input.CreatedTime,
                NumberOfItems = input.Pizzas.Count(),
                OrderId = input.OrderId,
                OrderStatus = Enum.GetName(input.Status),
                TotalPrice = input.Pizzas.Sum(p => p.Special.BasePrice / 12 * p.Size)
            };
        }

        public static OrderDto ToOrderDto(Order input)
        {
            return new OrderDto
            {
                OrderId = input.OrderId,
                CreatedTime = input.CreatedTime,
                DeliveryAddress = new AddressDto
                {
                    City = input.DeliveryAddress.City,
                    Line1 = input.DeliveryAddress.Line1,
                    Line2 = input.DeliveryAddress.Line2,
                    Name = input.DeliveryAddress.Name,
                    PostalCode = input.DeliveryAddress.PostalCode,
                    Region = input.DeliveryAddress.Region
                },
                Pizzas = input.Pizzas.Select(PizzaMapper.ToPizzaDto).ToArray()
            };
        }

        public static OrderWithStatusDto ToOrderWithStatusDto(Order input)
        {
            return new OrderWithStatusDto
            {
                Order = ToOrderDto(input),
                StatusText = Enum.GetName(input.Status)!
            };
        }

        public static OrderPlaced ToOrderPlacedEvent(Order input)
        {
            return new OrderPlaced
            {
                OrderId = input.OrderId,
                CreatedTime = input.CreatedTime,
                DeliveryAddress = new OrderPlacedAddress
                {
                    City = input.DeliveryAddress.City,
                    Line1 = input.DeliveryAddress.Line1,
                    Line2 = input.DeliveryAddress.Line2,
                    Name = input.DeliveryAddress.Name,
                    PostalCode = input.DeliveryAddress.PostalCode,
                    Region = input.DeliveryAddress.Region
                },
                Pizzas = input.Pizzas
                    .Select(
                        p => new OrderPlacedPizza
                        {
                            Description = p.Special.Description,
                            Name = p.Special.Name,
                            Size = p.Size,
                            Toppings = p.Toppings
                                .Select(t => t.Name)
                                .ToArray()
                        }
                    ).ToArray()
            };
        }
    }
}
