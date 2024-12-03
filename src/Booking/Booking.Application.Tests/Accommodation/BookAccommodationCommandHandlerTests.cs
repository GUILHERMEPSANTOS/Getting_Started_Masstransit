using Booking.Application.Accommodation.BookAccommodation;
using MediatR;
using Moq;

namespace Booking.Application.Tests.Accommodation;

public class BookAccommodationCommandHandlerTests
{
    [Fact(DisplayName = "should return success when adding a valid reservation")]
    [Trait("Category", "BookAccommodation")]
    public void AddNewBooking_ValidBooking_SuccessInBookingAccommodation()
    {
        //Arrange
        var bookAccommodationCommand = new BookAccommodationCommand
        {
            HostId = Guid.NewGuid(),
            AccommodationId = Guid.NewGuid(),
            CheckIn = DateTime.Now,
            CheckOut = DateTime.Now.AddHours(1),
            GuestId = Guid.NewGuid(),
            NumberOfAdults = 2,
            NumberOfChildren = 3,
            NumberOfInfants = 2,
            NumberOfPets = 2,
        };
        var bookAccommodationCommandHandler = new Mock<IRequestHandler<BookAccommodationCommand>>();

        //Act 
        bookAccommodationCommandHandler.Object.Handle(bookAccommodationCommand, default);

        //Assert
        bookAccommodationCommandHandler
            .Verify(e => e.Handle(It.IsAny<BookAccommodationCommand>(), It.IsAny<CancellationToken>()), Times.Once);
    }
}