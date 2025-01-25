﻿namespace Booking.Common.Domain
{
    public interface IDomainEvent
    {
        Guid Id { get; }
        DateTime OccurredAtUtc { get; }
    }
}
