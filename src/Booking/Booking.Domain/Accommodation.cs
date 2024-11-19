namespace Booking.Domain;

public class Accommodation
{
    public Guid Id { get; private set; }
    public Guid HostId { get; private set; }
    private readonly List<Booking> _bookings;
    public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

    private Accommodation(Guid id, Guid hostId, List<Booking> bookings)
    {
        Id = id;
        HostId = hostId;
        _bookings = bookings;
    }

    public static Accommodation Create(Guid hostId)
    {
        return new Accommodation(Guid.NewGuid(), hostId, new List<Booking>());
    }

    public bool IsAvailable(DateTime checkIn, DateTime checkOut)
    {
        return true; //!_bookings.Any(booking => booking.CheckIn   && booking.CheckOut <= checkOut);
    }

    public void AddBooking(Booking booking)
    {
        if (IsAvailable(booking.CheckIn, booking.CheckOut))
        {
            _bookings.Add(booking); 
        }
    }
}