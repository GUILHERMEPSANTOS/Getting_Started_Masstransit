using System.Windows.Input;
using MediatR;

namespace Booking.Application.Accommodation.CreateAccommodation;

public class CreateAccommodationCommand : IRequest
{
    public Guid HostId { get; set; }
    public string Name { get; set; }

    #region Address
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string Neighborhood { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    #endregion
}