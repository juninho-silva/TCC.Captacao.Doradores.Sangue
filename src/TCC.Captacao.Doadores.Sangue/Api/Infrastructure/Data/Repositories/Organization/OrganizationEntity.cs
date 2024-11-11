using Api.Infrastructure.Data.Repositories.Organization.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.Organization
{
    /// <summary>
    /// Entidade Organizacao
    /// </summary>
    public class OrganizationEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        [BsonElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// CNPJ
        /// </summary>
        [BsonElement("cnpj")]
        public string Cnpj { get; set; }
        /// <summary>
        /// Endereco
        /// </summary>
        [BsonElement("address")]
        public Address Address { get; set; }
        /// <summary>
        /// Contato
        /// </summary>
        [BsonElement("contact")]
        public Contact Contact { get; set; }
        /// <summary>
        /// Horario de Funcionamento
        /// </summary>
        [BsonElement("operatingHours")]
        public OperatingHours OperatingHours { get; set; }
        /// <summary>
        /// Id do Usuario
        /// </summary>
        [BsonElement("userId")]
        public string UserId { get; set; }
        /// <summary>
        /// Data de Criacao
        /// </summary>
        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Data de Alteracao
        /// </summary>
        [BsonElement("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
