using MassTransit;
using Booking.Common.Application.EventBus;

namespace Booking.Common.Infrastructure.EventBus
{
    public class EventBus(IBus bus) : IEventBus
    {
        public async Task PublishAsync<TIntregationEvent>(TIntregationEvent @event, CancellationToken cancellation) where TIntregationEvent : IIntegrationEvent
        {
            await bus.Publish(@event, cancellation);
        }
    }
}
