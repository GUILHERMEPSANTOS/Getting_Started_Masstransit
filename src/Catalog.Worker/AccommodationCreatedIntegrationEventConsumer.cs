using Booking.Events.IntegrationEvents;
using MassTransit;

namespace Catalog.Worker;

public class AccommodationCreatedIntegrationEventConsumer : IConsumer<AccommodationCreatedIntegrationEvent>
{
    public Task Consume(ConsumeContext<AccommodationCreatedIntegrationEvent> context)
    {
        var integrationEvent = context.Message;

        return Task.CompletedTask;
    }
}