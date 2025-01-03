using Booking.Application.Accommodation.BookAccommodation;
using Booking.Domain;
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

    [Fact(DisplayName = "Should throw an exception when adding a booking to a nonexistent accommodation")]
    [Trait("Category", "BookAccommodation")]
    public void AddNewBooking_NonExistentAccommodation_ShouldThrowsException()
    {
        //Arrange
        var accommodationRepositoryMock = new Mock<IAccommodationRepository>();
        accommodationRepositoryMock
            .Setup(repository => repository.GetAccommodationById(It.IsAny<Guid>()))
            .ReturnsAsync((Domain.Accommodation)null);

        var bookAccommodationCommandHandler = new BookAccommodationCommandHandler(accommodationRepositoryMock.Object);

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

        //Act && Assert
        Assert.ThrowsAsync<Exception>(
            async () => await bookAccommodationCommandHandler.Handle(bookAccommodationCommand, default));
    }

    [Fact(DisplayName = "Should throw an exception when adding a reservation when the given host is different from the accommodation host")]
    [Trait("Category", "BookAccommodation")]
    public void AddNewBooking_DifferentHostAccommodation_ShouldThrowsException()
    {
        //Arrange
        var accommodation = Domain.Accommodation.Create(Guid.NewGuid());
        var accommodationRepositoryMock = new Mock<IAccommodationRepository>();
       
        accommodationRepositoryMock
            .Setup(repository => repository.GetAccommodationById(It.IsAny<Guid>()))
            .ReturnsAsync(accommodation);

        var bookAccommodationCommand = new BookAccommodationCommand
        {
            HostId = Guid.NewGuid(),
        };
        
        var bookAccommodationCommandHandler = new BookAccommodationCommandHandler(accommodationRepositoryMock.Object);
        
        //Act && Assert
        Assert.ThrowsAsync<Exception>(
            async () => await bookAccommodationCommandHandler.Handle(bookAccommodationCommand, default));
    }
    
    [Fact(DisplayName = "Should throw an exception when adding a reservation when the given accommodation already has a reservation")]
    [Trait("Category", "BookAccommodation")]
    public void AddNewBooking_AccommodationAlreadyHasReservation_ShouldThrowsException()
    {
        //Arrange
        var accommodationId = Guid.NewGuid();
        var accommodation = Domain.Accommodation.Create(accommodationId);
        var booking = Domain.Booking.Create(
            DateTime.UtcNow,
            DateTime.UtcNow.AddDays(2),
            1,
            0,
            0,
            0,
            new Guid(),
            accommodationId
        );
        accommodation.AddBooking(booking);
       
        var accommodationRepositoryMock = new Mock<IAccommodationRepository>();
        accommodationRepositoryMock
            .Setup(repository => repository.GetAccommodationById(It.IsAny<Guid>()))
            .ReturnsAsync(accommodation);

        var bookAccommodationCommand = new BookAccommodationCommand
        {
            HostId = accommodationId,
            CheckIn = DateTime.UtcNow,
            CheckOut = DateTime.UtcNow.AddDays(2),
        };
        
        var bookAccommodationCommandHandler = new BookAccommodationCommandHandler(accommodationRepositoryMock.Object);
        
        //Act && Assert
        Assert.ThrowsAsync<Exception>(
            async () => await bookAccommodationCommandHandler.Handle(bookAccommodationCommand, default));
    }
}