using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Booking.Domain;

public class Booking
{
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; private set; }


    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }
    public int NumberOfAdults { get; private set; }
    public int NumberOfChildren { get; private set; }
    public int NumberOfInfants { get; private set; }
    public int NumberOfPets { get; private set; }
    public bool CheckInCompleted { get; private set; }
    public bool CheckOutCompleted { get; private set; }

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid GuestId { get; private set; }

    public BookingStatus Status { get; private set; }

    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid AccommodationId { get; private set; }

    private Booking(
        Guid id,
        DateTime checkIn,
        DateTime checkOut,
        int numberOfAdults,
        int numberOfChildren,
        int numberOfInfants,
        int numberOfPets,
        Guid guestId,
        BookingStatus bookingStatus,
        bool checkInCompleted,
        bool checkOutCompleted,
        Guid accommodationId)
    {
        Id = id;
        CheckIn = checkIn;
        CheckOut = checkOut;
        NumberOfAdults = numberOfAdults;
        NumberOfChildren = numberOfChildren;
        NumberOfInfants = numberOfInfants;
        NumberOfPets = numberOfPets;
        GuestId = guestId;
        Status = bookingStatus;
        CheckInCompleted = checkInCompleted;
        CheckOutCompleted = checkOutCompleted;
        AccommodationId = accommodationId;
    }

    public static Booking Create(
        DateTime checkIn,
        DateTime checkOut,
        int numberOfAdults,
        int numberOfChildren,
        int numberOfInfants,
        int numberOfPets,
        Guid guestId,
        Guid accommodationId
    )
    {
        if (checkIn == checkOut) throw new Exception("Check-in can not be equal check-out date");

        if (checkIn > checkOut) throw new Exception("Check-in Date can not be earlier than check-out date");
        
        return new Booking(
            Guid.NewGuid(),
            checkIn,
            checkOut,
            numberOfAdults,
            numberOfChildren,
            numberOfInfants,
            numberOfPets,
            guestId,
            BookingStatus.Pending,
            false,
            false,
            accommodationId
        );
    }

    public void SetConfirmed()
        => Status = BookingStatus.Confirmed;

    public void DoCheckIn()
    {
        if (BookingStatus.Confirmed != Status)
        {
            throw new Exception("The booking status is not confirmed");
        }

        CheckIn = DateTime.UtcNow;
        CheckInCompleted = true;
    }
}

public enum BookingStatus
{
    Pending = 0,
    Confirmed = 1,
    Cancelled = 2,
    Completed = 3,
    NoShow = 4
}