namespace Booking.Domain;

public class Booking
{
    public Guid Id { get; private set; }
    public DateTime CheckIn { get; private set; }
    public DateTime CheckOut { get; private set; }
    public int NumberOfAdults { get; private set; }
    public int NumberOfChildren { get; private set; }
    public int NumberOfInfants { get; private set; }
    public int NumberOfPets { get; private set; }
    public bool CheckInCompleted { get; private set; }
    public bool CheckOutCompleted { get; private set; }
    public Guid GuestId { get; private set; }
    public BookingStatus Status { get; private set; }

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
        bool checkOutCompleted)
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
    }

    public static Booking Create(
        DateTime checkIn,
        DateTime checkOut,
        int numberOfAdults,
        int numberOfChildren,
        int numberOfInfants,
        int numberOfPets,
        Guid guestId
    )
    {
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
            false
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