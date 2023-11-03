using BlazingPizza.Application.Shared;
using BlazingPizza.Domain.Kitchen.Events;
using BlazingPizza.Domain.Ordering;
using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Domain.Ordering.Enums;

namespace BlazingPizza.Application.Ordering.EventConsumers
{
    public class OrderProcessingConsumer : EventConsumer<OrderProcessing>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderProcessingConsumer(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task HandleEvent(OrderProcessing @event)
        {
            var order = _unitOfWork.Orders.FindOne<Order>(o => o.OrderId == @event.OrderId);
            order.Status = OrderStatus.Processing;

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
