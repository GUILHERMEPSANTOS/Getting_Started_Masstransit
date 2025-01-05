using Booking.Domain;
using MediatR;
using Microsoft.VisualBasic;

namespace Booking.Application.Accommodation.CreateAccommodation;

public class CreateAccommodationCommandHandler(IAccommodationRepository _accommodationRepository)
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
    }
}