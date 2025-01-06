using MongoDB.Bson.Serialization;

namespace Booking.Infrastructure.Accommodation;

public static class AccommodationConfiguration
{
    public static void Configure()
    {
        BsonClassMap.RegisterClassMap<Domain.Accommodation>(classMap =>
        {
            classMap.AutoMap();
            classMap.MapProperty(accommodation => accommodation.Address).SetElementName("Address");
            classMap.MapProperty(accommodation => accommodation.Bookings).SetElementName("Bookings")
                .SetDefaultValue(new List<Domain.Booking>() { });
        });
    }
}