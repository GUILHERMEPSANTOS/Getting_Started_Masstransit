using Booking.Domain;
using Booking.Infrastructure.Database;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Booking.Infrastructure.Accommodation;

public class AccommodationRepository : IAccommodationRepository
{
    private readonly IMongoCollection<Domain.Accommodation> _accommodationsCollection;

    public AccommodationRepository(IMongoClient _client)
    {
        IMongoDatabase mongoDatabase = _client.GetDatabase(DocumentDbSettings.Database);

        _accommodationsCollection =
            mongoDatabase.GetCollection<Domain.Accommodation>(DocumentDbSettings.Accommodations);
    }

    public async Task AddBooking(Guid accommodationId, Domain.Booking booking)
    {
        var filter = Builders<Domain.Accommodation>.Filter.Eq(a => a.Id, accommodationId);
        
        await _accommodationsCollection
            .UpdateOneAsync(filter,
                Builders<Domain.Accommodation>
                    .Update
                    .AddToSet(accommodation => accommodation.Bookings, booking));
    }

    public async Task<Domain.Accommodation> GetAccommodationById(Guid id)
    {
        var accommodationResult =
            await _accommodationsCollection.FindAsync(accommodation => accommodation.Id == id);

        return accommodationResult.SingleOrDefault();
    }
}