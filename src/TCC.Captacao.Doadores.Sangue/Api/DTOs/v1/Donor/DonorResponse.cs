namespace Api.DTOs.v1.Donor
{
    /// <summary>
    /// Doador
    /// </summary>
    public class DonorResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nome Completo
        /// </summary>
        public DonorFullNameResponse FullName { get; set; }
        /// <summary>
        /// CPF
        /// </summary>
        public string Cpf { get; set; }
        /// <summary>
        /// Endereco
        /// </summary>
        public DonorAddressResponse Address { get; set; }
        /// <summary>
        /// Contato
        /// </summary>
        public DonorContactResponse Contact { get; set; }
        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// Genero
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Tipo Sanguineo
        /// </summary>
        public string BloodType { get; set; }
        /// <summary>
        /// Data de Criacao
        /// </summary>
        public DateTime CreateAt { get; set; }
        /// <summary>
        /// Data de Alteracao
        /// </summary>
        public DateTime UpdateAt { get; set; }
    }

    /// <summary>
    /// Nome Completo do Doador
    /// </summary>
    public class DonorFullNameResponse
    {
        /// <summary>
        /// Primeiro Nome
        /// </summary>
        public string First { get; set; }
        /// <summary>
        /// Ultimo Nome
        /// </summary>
        public string Last { get; set; }
    }

    /// <summary>
    /// Endereco do Doador
    /// </summary>
    public class DonorAddressResponse
    {
        /// <summary>
        /// Rua
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// Numero
        /// </summary>
        public string Number { get; set; }
        /// <summary>
        /// Bairro
        /// </summary>
        public string Neighborhood { get; set; }
        /// <summary>
        /// Cidade
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// Estado
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// CEP
        /// </summary>
        public string ZipCode { get; set; }
    }

    /// <summary>
    /// Contato do Doador
    /// </summary>
    public class DonorContactResponse
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string Phone { get; set; }
    }
}
