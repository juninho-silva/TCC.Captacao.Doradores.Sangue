namespace Api.Infrastructure.Smtp
{
    /// <summary>
    /// SMTP Mapeamento Configuracoes
    /// </summary>
    public class SmtpSettings
    {
        /// <summary>
        /// Servidor
        /// </summary>
        public string Server { get; set; }
        /// <summary>
        /// Porta
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Nome do envio
        /// </summary>
        public string SenderName { get; set; }
        /// <summary>
        /// Email para envio
        /// </summary>
        public string SenderEmail { get; set; }
        /// <summary>
        /// Login
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// Senha
        /// </summary>
        public string Password { get; set; }
    }
}
