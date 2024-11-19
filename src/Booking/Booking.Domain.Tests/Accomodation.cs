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
            new Guid()
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
            Guid.NewGuid()
        ); 
        
        var secondBooking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            Guid.NewGuid()
        );

        //Act
        accomodation.AddBooking(firstBooking);
        accomodation.AddBooking(secondBooking);

        //Assert
        Assert.DoesNotContain(accomodation.Bookings, booking => booking.Id == secondBooking.Id);
    }
}