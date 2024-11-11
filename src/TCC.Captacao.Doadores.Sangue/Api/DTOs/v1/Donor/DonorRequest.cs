using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.DTOs.v1.Donor
{
    /// <summary>
    /// Doador
    /// </summary>
    public class DonorRequest
    {
        /// <summary>
        /// Novo Usuário 
        /// </summary>
        [JsonPropertyName("user")]
        public DonorUserRequest User { get; set; }

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
        /// Endereco
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
        /// Genêro
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

    /// <summary>
    /// Novo usuário doador
    /// </summary>
    public class DonorUserRequest
    {
        /// <summary>
        /// Nome do usuário
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

        /// <summary>
        /// E-mail de usuário 
        /// </summary>
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Necessário informar um e-mail usuário")]
        public string Email { get; set; }
    }

    /// <summary>
    /// Nome Completo do doador
    /// </summary>
    public class DonorFullNameRequest
    {
        /// <summary>
        /// Primeiro Nome
        /// </summary>
        [JsonPropertyName("first")]
        [Required(ErrorMessage = "Necessário informar o primeiro nome")]
        public string First { get; set; }

        /// <summary>
        /// Ultimo Nome
        /// </summary>
        [JsonPropertyName("last")]
        [Required(ErrorMessage = "Necessário informar o ultimo nome")]
        public string Last { get; set; }
    }

    /// <summary>
    /// Endereco do doador
    /// </summary>
    public class DonorAddressRequest
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
    /// Contato do doador
    /// </summary>
    public class DonorContactRequest
    {
        /// <summary>
        /// E-mail para contato 
        /// </summary>
        [JsonPropertyName("email")]
        [Required(ErrorMessage = "Necessário informar o e-mail para contato")]
        public string Email { get; set; }

        /// <summary>
        /// Telefone
        /// </summary>
        [JsonPropertyName("phone")]
        public string Phone { get; set; }
    }
}
