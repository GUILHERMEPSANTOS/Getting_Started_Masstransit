using Booking.Domain;
using MediatR;

namespace Booking.Application.Accommodation.BookAccommodation;

public class BookAccommodationCommandHandler(IAccommodationRepository _accommodationRepository)
    : IRequestHandler<BookAccommodationCommand>
{
    public async Task Handle(BookAccommodationCommand request, CancellationToken cancellationToken)
    {
        var accommodation = await _accommodationRepository.GetAccommodationById(request.AccommodationId);

        if (accommodation is null) throw new Exception("Accommodation dosen't exist");

        if (accommodation.HostId != request.HostId) throw new Exception("Accommodation does not belong to the host");

        var bookingAttempt = Domain.Booking.Create(
            request.CheckIn,
            request.CheckOut,
            request.NumberOfAdults,
            request.NumberOfChildren,
            request.NumberOfInfants,
            request.NumberOfPets,
            request.GuestId,
            request.AccommodationId
        );

        var bookingAttemptResult = accommodation.AddBooking(bookingAttempt);

        if (!bookingAttemptResult) throw new Exception("A booking already exists for this period.");

        await _accommodationRepository.AddBooking(accommodation.Id, bookingAttempt);
    }
}