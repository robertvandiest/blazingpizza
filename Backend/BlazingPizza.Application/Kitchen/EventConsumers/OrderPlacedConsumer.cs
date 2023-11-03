using BlazingPizza.Application.Shared;
using BlazingPizza.Domain.Kitchen;
using BlazingPizza.Domain.Kitchen.Entities;
using BlazingPizza.Domain.Kitchen.Events;
using BlazingPizza.Domain.Ordering.Events;
using BlazingPizza.Domain.Shared;

namespace BlazingPizza.Application.Kitchen.EventConsumers
{
    public class OrderPlacedConsumer : EventConsumer<OrderPlaced>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventFactory _eventFactory;

        public OrderPlacedConsumer(IUnitOfWork unitOfWork, IEventFactory eventFactory)
        {
            _unitOfWork = unitOfWork;
            _eventFactory = eventFactory;
        }

        public override async Task HandleEvent(OrderPlaced @event)
        {
            _unitOfWork.Orders.CreateOne(MapToOrder(@event));

            await _unitOfWork.SaveChangesAsync();

            await _eventFactory.RaiseEventAsync<OrderProcessing>(new() { OrderId = @event.OrderId });
        }

        public Order MapToOrder(OrderPlaced input)
        {
            return new Order
            {
                OrderId = input.OrderId,
                CreatedTime = input.CreatedTime,
                DeliveryAddress = new Address
                {
                    City = input.DeliveryAddress.City,
                    Line1 = input.DeliveryAddress.Line1,
                    Line2 = input.DeliveryAddress.Line2,
                    Name = input.DeliveryAddress.Name,
                    PostalCode = input.DeliveryAddress.PostalCode,
                    Region = input.DeliveryAddress.Region,
                },
                Pizzas = input.Pizzas
                .Select(
                    p => new Pizza
                    {
                        Name = p.Name,
                        Size = p.Size,
                        Toppings = p.Toppings.Select(p => new Topping { Name = p }).ToArray()
                    }
                ).ToArray()
            };
        }
    }
}
