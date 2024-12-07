namespace Booking.Domain;

public interface IAccommodationRepository
{
    void AddBooking(Booking booking);
    Task<Accommodation?> GetAccommodationById(Guid id);
}