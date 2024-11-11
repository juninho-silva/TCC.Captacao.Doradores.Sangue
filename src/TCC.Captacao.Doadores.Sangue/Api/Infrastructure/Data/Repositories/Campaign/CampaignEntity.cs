using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.Campaign
{
    /// <summary>
    /// Entidade Campanha
    /// </summary>
    public class CampaignEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Titulo
        /// </summary>
        [BsonElement("title")]
        public string Title { get; set; }
        /// <summary>
        /// Descricao
        /// </summary>
        [BsonElement("description")]
        public string Description { get; set; }
        /// <summary>
        /// Tipo Sanguineo
        /// </summary>
        [BsonElement("bloodType")]
        public string BloodType { get; set; }
        /// <summary>
        /// Id da Organizacao (Banco de Sangue)
        /// </summary>
        [BsonElement("organizationId")]
        public string OrganizationId { get; set; }
    }
}
