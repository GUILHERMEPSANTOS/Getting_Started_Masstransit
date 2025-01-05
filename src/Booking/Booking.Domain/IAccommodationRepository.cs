namespace Booking.Domain;

public interface IAccommodationRepository
{
    Task AddBooking(Guid accommodationId, Booking booking);
    Task<Accommodation?> GetAccommodationById(Guid id);
    Task Create(Accommodation accommodation);
}