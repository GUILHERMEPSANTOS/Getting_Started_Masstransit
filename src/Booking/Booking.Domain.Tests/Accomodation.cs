namespace Booking.Domain.Tests;

public class Accomodation
{
    [Trait("Category", "Accomodation")]
    [Fact(DisplayName = "Accomodation created successfully")]
    public void AddBooking_AccomodationWithNewBooking_BookingStatePending()
    {
        // Arrange 
        var accomodation = Accommodation.Create(Guid.NewGuid());
        var booking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            new Guid(),
            accomodation.Id
        );

        //Act
        accomodation.AddBooking(booking);

        //Assert
        Assert.True(accomodation.Bookings.Any());
    }

    [Trait("Category", "Accomodation")]
    [Fact(DisplayName = "Failed to add a new reservation because one already exists in the same period")]
    public void AddBooking_FailureAddNewBooking_BookingAlreadyExists()
    {
        // Arrange 
        var accomodation = Accommodation.Create(Guid.NewGuid());
        var firstBooking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            Guid.NewGuid(),
            accomodation.Id
        );

        var secondBooking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            Guid.NewGuid(),
            accomodation.Id
        );

        var thirdBooking = Booking.Create(DateTime.UtcNow.AddDays(-2),
            DateTime.UtcNow.AddDays(4),
            1,
            0,
            0,
            0,
            Guid.NewGuid(),
            accomodation.Id
        );

        //Act
        var bookingAttempt1 = accomodation.AddBooking(firstBooking);
        var bookingAttempt2 = accomodation.AddBooking(secondBooking);
        var bookingAttempt3 = accomodation.AddBooking(thirdBooking);

        //Assert
        Assert.True(bookingAttempt1);
        Assert.False(bookingAttempt2);
        Assert.False(bookingAttempt3);
    }
}