namespace Booking.Domain;

public class Accommodation
{
    public Guid Id { get; private set; }
    public Guid HostId { get; private set; }
    public string Name { get; set; }
    public Address Address { get; set; }

    private readonly List<Booking> _bookings = [];
    public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly();

    private Accommodation(Guid id, Guid hostId, string name, Address address)
    {
        Id = id;
        HostId = hostId;
        Name = name;
        Address = address;
    }

    public static Accommodation Create(Guid hostId, string name, Address address)
    {
        return new Accommodation(Guid.NewGuid(), hostId, name, address);
    }

    private bool IsAvailable(DateTime checkIn, DateTime checkOut)
    {
        if (!_bookings.Any()) return true;

        return !_bookings.Any(booking => checkIn < booking.CheckOut && checkOut > booking.CheckIn);
    }

    public bool AddBooking(Booking booking)
    {
        if (IsAvailable(booking.CheckIn, booking.CheckOut))
        {
            _bookings.Add(booking);

            return true;
        }

        return false;
    }
}