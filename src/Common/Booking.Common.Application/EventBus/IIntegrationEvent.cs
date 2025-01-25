using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Common.Application.EventBus
{
    public interface IIntegrationEvent
    {
        Guid Id { get; }
        DateTime OccurredAtUtc { get; }
    }
}
