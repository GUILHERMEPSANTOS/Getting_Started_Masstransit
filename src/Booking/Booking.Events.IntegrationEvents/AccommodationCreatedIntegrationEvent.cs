using Booking.Common.Application.EventBus;

namespace Booking.Events.IntegrationEvents
{
    public class AccommodationCreatedIntegrationEvent(
        Guid id,
        DateTime occurredAtUtc,
        string name,
        Guid accommodationId,
        Guid hostId) : IntegrationEvent(id, occurredAtUtc)
    {
        public Guid Id { get; } = id;
        public DateTime OccurredAtUtc { get; } = occurredAtUtc;
        public string Name { get; } = name;
        public Guid AccommodationId { get; } = accommodationId;
        public Guid HostId { get; } = hostId;
    }
}