using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mail;

namespace Api.Infrastructure.Smtp
{
    /// <summary>
    /// Camada Servico Email
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Construtor Camada Servico Email
        /// </summary>
        /// <param name="configuration"></param>
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Responsavel pelo envio de E-mail
        /// </summary>
        /// <param name="toEmail"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public async Task SendAsync(string toEmail, string subject, string body)
        {
            var smtpSettings = _configuration.GetSection("SmtpSettings").Get<SmtpSettings>();

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpSettings.SenderEmail, smtpSettings.SenderName),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(new MailAddress(toEmail));

            using var client = new SmtpClient(smtpSettings.Server, smtpSettings.Port);

#if DEBUG
            client.Credentials = CredentialCache.DefaultNetworkCredentials;
            client.EnableSsl = false;
#else
            client.Credentials = new NetworkCredential(smtpSettings.Username, smtpSettings.Password);
            client.EnableSsl = true;
#endif

            await client.SendMailAsync(mailMessage);
        }
    }
}
