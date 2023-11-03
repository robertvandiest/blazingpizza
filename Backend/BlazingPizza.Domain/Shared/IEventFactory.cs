namespace BlazingPizza.Domain.Shared
{
    public interface IEventFactory
    {
        public Task RaiseEventAsync<TEvent>(TEvent @event) where TEvent : class;
    }
}
