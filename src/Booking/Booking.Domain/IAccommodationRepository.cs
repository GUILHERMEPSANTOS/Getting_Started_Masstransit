namespace Booking.Domain;

public interface IAccommodationRepository
{
    Task AddBooking(Guid accommodationId, Domain.Booking booking);
    Task<Accommodation?> GetAccommodationById(Guid id);
}