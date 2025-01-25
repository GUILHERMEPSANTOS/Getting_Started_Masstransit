using Booking.Common.Application.EventBus;

namespace Booking.Events.IntegrationEvents
{
    public class AccommodationCreatedIntegrationEvent(
        Guid id, 
        DateTime occurredAtUtc,
        string Name,
        Guid AccommodationId,
        Guid HostId) : IntegrationEvent(id, occurredAtUtc)
    {
    }
}
