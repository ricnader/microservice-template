using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Enums;

namespace Application.DTOs.Distribuitor
{
    public class DistribuitorUpdateDTO
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public EDistribuitorType Type { get; set; }
    }
}
