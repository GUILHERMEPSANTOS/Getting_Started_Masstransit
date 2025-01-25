using Booking.Common.Application.EventBus;
using Booking.Domain;
using Booking.Events.IntegrationEvents;
using MediatR;

namespace Booking.Application.Accommodation.CreateAccommodation;

public class CreateAccommodationCommandHandler(IAccommodationRepository _accommodationRepository, IEventBus eventBus)
    : IRequestHandler<CreateAccommodationCommand>
{
    public async Task Handle(CreateAccommodationCommand request, CancellationToken cancellationToken)
    {
        var address = new Address(
            request.Street,
            request.Number,
            request.Complement,
            request.Neighborhood,
            request.City,
            request.State,
            request.ZipCode,
            request.Country
        );

        var accommodation = Domain.Accommodation.Create(request.HostId, request.Name, address);

        await _accommodationRepository.Create(accommodation);

        await eventBus.PublishAsync(new AccommodationCreatedIntegrationEvent(
            Guid.NewGuid(),
            DateTime.UtcNow,
            accommodation.Name, 
            accommodation.Id,
            accommodation.HostId
        ), cancellationToken);
    }
}