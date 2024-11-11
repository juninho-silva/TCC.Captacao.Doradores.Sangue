using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.Organization.Entities
{
    public class Address
    {
        [BsonElement("street")]
        public string Street { get; set; }
        [BsonElement("number")]
        public string Number { get; set; }
        [BsonElement("neighborhood")]
        public string Neighborhood { get; set; }
        [BsonElement("city")]
        public string City { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("zipCode")]
        public string ZipCode { get; set; }
    }
}
