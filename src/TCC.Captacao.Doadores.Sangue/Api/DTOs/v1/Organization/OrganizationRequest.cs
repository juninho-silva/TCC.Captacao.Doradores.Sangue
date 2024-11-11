using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.DTOs.v1.Organization
{
    /// <summary>
    /// Organizacao
    /// </summary>
    public class OrganizationRequest
    {
        /// <summary>
        /// Novo Usuário Organizador
        /// </summary>
        [JsonPropertyName("user")]
        public OrgUserRequest User { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [JsonPropertyName("name")]
        [Required(ErrorMessage = "Necessário informar o nome")]
        public string Name { get; set; }

        /// <summary>
        /// CNPJ
        /// </summary>
        [JsonPropertyName("cnpj")]
        [Required(ErrorMessage = "Necessário informar o CNPJ")]
        [MaxLength(14, ErrorMessage = "O CNPJ deve ter no máximo 14 caracteres")]
        public string Cnpj { get; set; }

        /// <summary>
        /// Endereco
        /// </summary>
        [JsonPropertyName("address")]
        public OrgAddressRequest Address { get; set; }

        /// <summary>
        /// Contato
        /// </summary>
        [JsonPropertyName("contact")]
        public OrgContactRequest Contact { get; set; }

        /// <summary>
        /// Horario de Funcionamento
        /// </summary>
        [JsonPropertyName("operatingHours")]
        public OrgOperatingHoursRequest OperatingHours { get; set; }
    }

    /// <summary>
    /// Usuário
    /// </summary>
    public class OrgUserRequest
    {
        /// <summary>
        /// Login
        /// </summary>
        [JsonPropertyName("username")]
        [Required(ErrorMessage = "Necessário informar nome de usuário")]
        public string Username { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Necessário informar uma senha")]
        public string Password { get; set; }
    }

    /// <summary>
    /// Endereco da Organização
    /// </summary>
    public class OrgAddressRequest
    {
        /// <summary>
        /// Rua
        /// </summary>
        [JsonPropertyName("street")]
        public string Street { get; set; }

        /// <summary>
        /// Numero
        /// </summary>
        [JsonPropertyName("number")]
        public string Number { get; set; }

        /// <summary>
        /// Bairro
        /// </summary>
        [JsonPropertyName("neighborhood")]
        public string Neighborhood { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        [JsonPropertyName("city")]
        public string City { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        [JsonPropertyName("zipCode")]
        public string ZipCode { get; set; }
    }

    /// <summary>
    /// Contato da Organizacao
    /// </summary>
    public class OrgContactRequest
    {
        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Necessário informar o E-mail")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }

    /// <summary>
    /// Horario de Funcionamento
    /// </summary>
    public class OrgOperatingHoursRequest
    {
        /// <summary>
        /// Hora de abertura
        /// </summary>
        [JsonPropertyName("openTime")]
        public string OpenTime { get; set; }

        /// <summary>
        /// Hora de fechamento
        /// </summary>
        [JsonPropertyName("closeTime")]
        public string CloseTime { get; set; }

        /// <summary>
        /// Dias de funcionamento
        /// </summary>
        [JsonPropertyName("daysOpen")]
        public List<string> DaysOpen { get; set; }
    }
}
