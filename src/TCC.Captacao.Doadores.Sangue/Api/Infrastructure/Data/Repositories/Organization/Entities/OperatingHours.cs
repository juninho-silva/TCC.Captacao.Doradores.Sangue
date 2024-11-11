using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.Organization.Entities
{
    public class OperatingHours
    {
        [BsonElement("openingTime")]
        public string OpeningTime { get; set; }
        [BsonElement("closingTime")]
        public string ClosingTime { get; set; }
        [BsonElement("daysOpen")]
        public List<string> DaysOpen { get; set; }
    }
}
