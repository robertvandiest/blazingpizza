using BlazingPizza.Application.Ordering.Dto;
using BlazingPizza.Application.Ordering.Mappers;
using BlazingPizza.Domain.Ordering;
using BlazingPizza.Domain.Ordering.Entities;
using BlazingPizza.Domain.Ordering.Enums;
using BlazingPizza.Domain.Shared;
using Microsoft.Extensions.Logging;

namespace BlazingPizza.Application.Ordering.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventFactory _eventFactory;
        private readonly ILogger<OrderService> _logger;

        public OrderService(
            IUnitOfWork unitOfWork,
            IEventFactory eventFactory,
            ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _eventFactory = eventFactory;
            _logger = logger;
        }

        public IReadOnlyCollection<OrderWithStatusDto> GetOrders()
        {
            return _unitOfWork.Orders
                .FindAll<Order>()
                .Select(OrderMapper.ToOrderWithStatusDto)
                .ToList()
                .AsReadOnly();
        }

        public IReadOnlyCollection<OrderSummaryDto> GetOrderSummaries()
        {
            return _unitOfWork.Orders
                .FindAll<Order>()
                .Select(OrderMapper.ToOrderSummaryDto)
                .ToList()
                .AsReadOnly();
        }

        public OrderWithStatusDto GetOrder(int orderId)
        {
            return _unitOfWork.Orders
                .FindAll<Order>(o => o.OrderId == orderId)
                .Select(OrderMapper.ToOrderWithStatusDto)
                .Single();
        }

        public async Task<int> SubmitOrder(OrderDto dto)
        {
            var order = OrderMapper.ToOrderEntity(dto);
            order.CreatedTime = DateTime.Now;
            order.Status = OrderStatus.Submitted;

            _unitOfWork.Orders.CreateOne(order);
            await _unitOfWork.SaveChangesAsync();

            var @event = OrderMapper.ToOrderPlacedEvent(order);
            await _eventFactory.RaiseEventAsync(@event);

            return order.OrderId;
        }
    }
}
