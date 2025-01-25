
using System.Drawing;

namespace Booking.Common.Domain
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; }

        public DateTime OccurredAtUtc { get; }


        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccurredAtUtc = DateTime.UtcNow;
        }

        protected DomainEvent(Guid id, DateTime occurredAtUtc)
        {
            Id = id;
            OccurredAtUtc = occurredAtUtc;
        }
    }
}
