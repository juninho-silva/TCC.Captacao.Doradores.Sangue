using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Infrastructure.Data.Repositories.User
{
    /// <summary>
    /// Entidade Usuario
    /// </summary>
    public class UserEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        /// <summary>
        /// Nome de Usuario
        /// </summary>
        [BsonElement("username")]
        public string Username { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        [BsonElement("password")]
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [BsonElement("email")]
        public string Email { get; set; }
        /// <summary>
        /// Data de Criacao
        /// </summary>
        [BsonElement("createdAt")]
        public string CreatedAt { get; set; }
        /// <summary>
        /// Data de Alteracao
        /// </summary>
        [BsonElement("updatedAt")]
        public string UpdatedAt { get; set; }
    }
}
