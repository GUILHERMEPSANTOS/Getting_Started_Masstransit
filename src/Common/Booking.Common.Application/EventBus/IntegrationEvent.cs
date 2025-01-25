namespace Booking.Common.Application.EventBus
{
    public abstract class IntegrationEvent(Guid id, DateTime occurredAtUtc) : IIntegrationEvent
    {
        public Guid Id { get; } = id;
        public DateTime OccurredAtUtc { get; } = occurredAtUtc;
    }
}
