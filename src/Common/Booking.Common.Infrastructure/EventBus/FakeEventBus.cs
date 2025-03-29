using Booking.Common.Application.EventBus;

namespace Booking.Common.Infrastructure.EventBus
{
    public class FakeEventBus : IEventBus
    {
        public Task PublishAsync<TIntregationEvent>(TIntregationEvent @event, CancellationToken cancellation) where TIntregationEvent : IIntegrationEvent
        {
            throw new NotImplementedException();
        }
    }
}
