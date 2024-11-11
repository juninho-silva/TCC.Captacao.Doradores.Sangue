namespace Api.Infrastructure.Smtp
{
    /// <summary>
    /// Interface Camada Servico Email
    /// </summary>
    public interface IEmailService
    {
        /// <summary>
        /// Responsavel pelo envio por E-mail
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        Task SendAsync(string toEmail, string subject, string body);
    }
}
