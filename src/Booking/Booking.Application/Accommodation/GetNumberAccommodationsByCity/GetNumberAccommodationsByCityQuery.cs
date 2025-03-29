using MediatR;

namespace Booking.Application.Accommodation.GetNumberAccommodationsByCity;

public class GetNumberAccommodationsByCityQuery : IRequest<int>
{
    public string City { get; set; }
}
