using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Booking.Domain;

public class Accommodation
{
    [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; private set; }

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid HostId { get; private set; }

    public string Name { get; set; }
    public Address Address { get; set; }

    public List<Booking> Bookings = [];

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
        if (Bookings.Count == 0) return true;

        return !Bookings.Any(booking => checkIn < booking.CheckOut && checkOut > booking.CheckIn);
    }

    public bool AddBooking(Booking booking)
    {
        if (IsAvailable(booking.CheckIn, booking.CheckOut))
        {
            Bookings.Add(booking);

            return true;
        }

        return false;
    }
}