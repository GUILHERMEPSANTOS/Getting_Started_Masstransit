namespace Booking.Common.Application.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync<TIntregationEvent>(TIntregationEvent @event, CancellationToken cancellation)
            where TIntregationEvent : IIntegrationEvent;
    }
}
