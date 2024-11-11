namespace Api.DTOs.v1.Organization
{
    /// <summary>
    /// Organizacao (Banco de Sangue) Response
    /// </summary>
    public class OrganizationResponse
    {
        /// <summary>
        /// Id
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Nome
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// CNPJ
        /// </summary>
        public string Cnpj { get; set; }
        /// <summary>
        /// Endereco
        /// </summary>
        public OrgAddressResponse Address { get; set; }
        /// <summary>
        /// Contato
        /// </summary>
        public OrgContactResponse Contact { get; set; }
        /// <summary>
        /// Horario de Funcionamento
        /// </summary>
        public OrgOperatingHoursResponse OperatingHours { get; set; }
        /// <summary>
        /// Data de Criacao
        /// </summary>
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Data de Alteracao
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }

    /// <summary>
    /// Endereco da Organizacao
    /// </summary>
    public class OrgAddressResponse
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
    /// Contato da Organizacao
    /// </summary>
    public class OrgContactResponse
    {
        /// <summary>
        /// E-mail
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Telefone
        /// </summary>
        public string Phone { get; set; }
    }

    /// <summary>
    /// Horario de Funcionamento da Organizacao
    /// </summary>
    public class OrgOperatingHoursResponse
    {
        /// <summary>
        /// Horario Abertura
        /// </summary>
        public string OpenTime { get; set; }
        /// <summary>
        /// Horario Fechamento
        /// </summary>
        public string CloseTime { get; set; }
        /// <summary>
        /// Dias de Funcionamento
        /// </summary>
        public List<string> DaysOpen { get; set; }
    }
}
