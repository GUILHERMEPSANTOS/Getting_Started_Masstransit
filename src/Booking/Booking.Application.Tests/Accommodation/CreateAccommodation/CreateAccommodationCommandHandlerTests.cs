using Booking.Application.Accommodation.CreateAccommodation;
using Booking.Domain;
using Moq;

namespace Booking.Application.Tests.Accommodation.CreateAccommodation;

public class CreateAccommodationCommandHandlerTests
{
    [Trait("Category", "Accommodation")]
    [Fact(DisplayName = "Successfully create new accommodation")]
    public void CreateAccommodation_NewValidAccommodation_SuccessfullyCreateNewAccommodation()
    {
        //Arrange
        var accommodationRepository = new Mock<IAccommodationRepository>();
        var command = new CreateAccommodationCommand
        {
            Street = "Street",
            HostId = Guid.NewGuid(),
            City = "City",
            Complement = "Complement",
            Country = "Country",
            Neighborhood = "Neighborhood",
            Number = "Number",
            State = "State",
            ZipCode = "ZipCode",
            Name = "Name",
        };
        var commandHandler = new CreateAccommodationCommandHandler(accommodationRepository.Object);
        
        //Act 
        commandHandler.Handle(command, default);

        //Assert
        accommodationRepository.Verify(repository => repository.Create(It.IsAny<Domain.Accommodation>()), Times.Once);
    }
}