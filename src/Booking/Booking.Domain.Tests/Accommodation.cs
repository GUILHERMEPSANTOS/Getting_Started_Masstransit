namespace Booking.Domain.Tests;

public class Accommodation
{
    [Trait("Category", "Accomodation")]
    [Fact(DisplayName = "Accomodation created successfully")]
    public void AddBooking_AccomodationWithNewBooking_BookingStatePending()
    {
        // Arrange 
        var address = new Address(
            "Rua Exemplo",
            "123",
            "Apto 45",
            "Centro",
            "São Paulo",
            "SP",
            "01000-000",
            "Brasil"
        );
        var accommodation = Domain.Accommodation.Create(Guid.NewGuid(), "Accomodation", address);
        var booking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            new Guid(),
            accommodation.Id
        );

        //Act
        accommodation.AddBooking(booking);

        //Assert
        Assert.True(accommodation.Bookings.Any());
    }

    [Trait("Category", "Accomodation")]
    [Fact(DisplayName = "Failed to add a new reservation because one already exists in the same period")]
    public void AddBooking_FailureAddNewBooking_BookingAlreadyExists()
    {
        // Arrange 
        var address = new Address(
            "Rua Exemplo",
            "123",
            "Apto 45",
            "Centro",
            "São Paulo",
            "SP",
            "01000-000",
            "Brasil"
        );
        var accommodation = Domain.Accommodation.Create(Guid.NewGuid(), "Accomodation", address);
        var firstBooking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            Guid.NewGuid(),
            accommodation.Id
        );

        var secondBooking = Booking.Create(DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            Guid.NewGuid(),
            accommodation.Id
        );

        var thirdBooking = Booking.Create(DateTime.UtcNow.AddDays(-2),
            DateTime.UtcNow.AddDays(4),
            1,
            0,
            0,
            0,
            Guid.NewGuid(),
            accommodation.Id
        );

        //Act
        var bookingAttempt1 = accommodation.AddBooking(firstBooking);
        var bookingAttempt2 = accommodation.AddBooking(secondBooking);
        var bookingAttempt3 = accommodation.AddBooking(thirdBooking);

        //Assert
        Assert.True(bookingAttempt1);
        Assert.False(bookingAttempt2);
        Assert.False(bookingAttempt3);
    }
}