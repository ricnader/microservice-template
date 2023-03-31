using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Application.Dtos
{
    public abstract class DTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
