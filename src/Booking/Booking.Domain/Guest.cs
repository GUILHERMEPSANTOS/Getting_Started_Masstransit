using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Booking.Domain;

public class Guest
{
    [BsonId, BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsActive { get; set; }
}