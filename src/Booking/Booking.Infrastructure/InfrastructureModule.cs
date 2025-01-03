using Booking.Domain;
using Booking.Infrastructure.Accommodation;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Booking.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, string connectionString)
    {
        var mongoSettings = MongoClientSettings.FromConnectionString(connectionString);

        serviceCollection.AddSingleton<IMongoClient>(new MongoClient(mongoSettings));
        serviceCollection.AddScoped<IAccommodationRepository, AccommodationRepository>();

        return serviceCollection;
    }
}