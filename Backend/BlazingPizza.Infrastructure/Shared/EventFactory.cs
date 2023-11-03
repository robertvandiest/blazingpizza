using BlazingPizza.Domain.Shared;
using MassTransit;

namespace BlazingPizza.Infrastructure.Shared
{
    public class EventFactory : IEventFactory
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public EventFactory(IBus publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task RaiseEventAsync<TEvent>(TEvent @event) where TEvent: class
        {
            await _publishEndpoint.Publish<TEvent>(@event);
        }
    }
}
