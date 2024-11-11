using Api.DTOs.v1.Notification;

namespace Api.Services.v1.Interfaces
{
    /// <summary>
    /// Interface da Camada Servico Notificacao
    /// </summary>
    public interface INotificationService
    {
        /// <summary>
        /// Responsavel por agendar o envio de campanha aos doadores
        /// </summary>
        /// <param name="request"></param>
        void ScheduleNotification(NotificationRequest request);
    }
}
