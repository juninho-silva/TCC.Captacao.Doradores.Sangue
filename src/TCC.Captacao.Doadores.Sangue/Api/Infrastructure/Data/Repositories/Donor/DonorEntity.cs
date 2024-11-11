using Api.Infrastructure.Data.Repositories.Donor.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.Donor
{
    /// <summary>
    /// Entidade Doador
    /// </summary>
    public class DonorEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Nome Completo
        /// </summary>
        [BsonElement("fullname")]
        public FullName FullName { get; set; }
        /// <summary>
        /// CPF
        /// </summary>
        [BsonElement("cpf")]
        public string Cpf { get; set; }
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
        /// Data de Nascimento
        /// </summary>
        [BsonElement("birthDate")]
        public string BirthDate { get; set; }
        /// <summary>
        /// Genero
        /// </summary>
        [BsonElement("gender")]
        public string Gender { get; set; }
        /// <summary>
        /// Tipo Sanguineo
        /// </summary>
        [BsonElement("bloodType")]
        public string BloodType { get; set; }
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
