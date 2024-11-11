using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.DTOs.v1.Donor
{
    /// <summary>
    /// Atualizar doador
    /// </summary>
    public class UpdateDonorRequest
    {
        /// <summary>
        /// Nome Completo
        /// </summary>
        [JsonPropertyName("fullName")]
        public DonorFullNameRequest FullName { get; set; }

        /// <summary>
        /// CPF
        /// </summary>
        [JsonPropertyName("cpf")]
        [Required(ErrorMessage = "Necessário informar o CPF")]
        [MaxLength(11, ErrorMessage = "O CPF deve ter no máximo 11 caracteres")]
        public string Cpf { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        [JsonPropertyName("address")]
        public DonorAddressRequest Address { get; set; }

        /// <summary>
        /// Contato
        /// </summary>
        [JsonPropertyName("contact")]
        public DonorContactRequest Contact { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [JsonPropertyName("birthDate")]
        [Required(ErrorMessage = "Necessário informar a Data de Nascimento")]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Genero
        /// </summary>
        [JsonPropertyName("gender")]
        [Required(ErrorMessage = "Necessário informar o gênero")]
        public string Gender { get; set; }

        /// <summary>
        /// Tipo Sanguineo
        /// </summary>
        [JsonPropertyName("bloodType")]
        [Required(ErrorMessage = "Necessário informar o tipo sanguineo")]
        [BloodType]
        public string BloodType { get; set; }
    }
}
