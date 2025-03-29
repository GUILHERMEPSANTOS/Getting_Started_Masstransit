using Booking.Application.Accommodation.GetNumberAccommodationsByCity;
using Booking.Domain;
using MediatR;

namespace Booking.Application.Accommodation.GetAccommodationsByAddress
{
    public class GetNumberAccommodationsByCityQueryHandler : IRequestHandler<GetNumberAccommodationsByCityQuery, int>
    {
        private readonly IAccommodationRepository accommodationRepository;

        public GetNumberAccommodationsByCityQueryHandler(IAccommodationRepository accommodationRepository)
        {
            this.accommodationRepository = accommodationRepository;
        }

        public async Task<int> Handle(GetNumberAccommodationsByCityQuery request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.City))
            {
                throw new Exception($"Por favor, informe o nome da cidade desejada.");
            }

            return await accommodationRepository.GetNumberAccommodationsByCity(request.City);            
        }
    }
}
