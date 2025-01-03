using MediatR;

namespace Booking.Application.Accommodation.BookAccommodation;

public class BookAccommodationCommand : IRequest
{
    public Guid AccommodationId { get; set; }
    public Guid HostId { get; set; }
    public DateTime CheckIn { get;  set; }
    public DateTime CheckOut { get;  set; }
    public int NumberOfAdults { get;  set; }
    public int NumberOfChildren { get;  set; }
    public int NumberOfInfants { get;  set; }
    public int NumberOfPets { get;  set; }
    public Guid GuestId { get;  set; }
    
}