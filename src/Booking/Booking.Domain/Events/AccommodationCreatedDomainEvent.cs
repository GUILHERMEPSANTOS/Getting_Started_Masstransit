using Booking.Common.Domain;

namespace Booking.Domain.Events
{
    public class AccommodationCreatedDomainEvent : DomainEvent
    {
        public Guid Id { get; private set; }
        public Guid HostId { get; private set; }
        public string Name { get; set; }        
    }
}
