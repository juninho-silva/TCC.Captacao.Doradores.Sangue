using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.Organization.Entities
{
    public class Contact
    {
        [BsonElement("email")]
        public string Email { get; set; }
        [BsonElement("phone")]
        public string Phone { get; set; }
    }
}
