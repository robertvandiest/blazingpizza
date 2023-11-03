using MassTransit;

namespace BlazingPizza.Application.Shared
{
    public abstract class EventConsumer<TEvent> : IConsumer<TEvent> where TEvent : class
    {
        public async Task Consume(ConsumeContext<TEvent> context)
        {
            await HandleEvent(context.Message);
        }

        public abstract Task HandleEvent(TEvent @event);
    }
}
