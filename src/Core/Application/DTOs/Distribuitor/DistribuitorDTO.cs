using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Domain.Enums;
using Application.Dtos;

namespace Application.DTOs.Distribuitor
{
    public class DistribuitorDTO : DTO
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("State")]
        public string State { get; set; }

        [BsonElement("City")]
        public string City { get; set; }

        [BsonElement("Neighborhood")]
        public string Neighborhood { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }

        [BsonElement("Number")]
        public string Number { get; set; }

        [BsonElement("Type")]
        public EDistribuitorType Type { get; set; }

        [BsonElement("Status")]
        public EDistribuitorStatus Status { get; set; }

        [BsonElement("DistribuitorHeadQuartersId")]
        public string DistribuitorHeadQuartersId { get; set; }

        [BsonElement("InactivatedDate")]
        public DateTime? InactivatedDate { get; set; }
    }
}
