using Booking.Domain;

namespace Booking.Infrastructure.Accommodation;

public class AccommodationRepository() : IAccommodationRepository
{
    public void AddBooking(Domain.Booking booking)
    {
        throw new NotImplementedException();
    }

    public Task<Domain.Accommodation> GetAccommodationById(Guid id)
    {
        throw new NotImplementedException();
    }
}