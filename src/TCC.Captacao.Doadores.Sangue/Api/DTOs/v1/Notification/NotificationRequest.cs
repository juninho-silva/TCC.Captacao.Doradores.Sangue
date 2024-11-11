using System.ComponentModel.DataAnnotations;

namespace Api.DTOs.v1.Notification
{
    /// <summary>
    /// Notificacao
    /// </summary>
    public class NotificationRequest
    {
        /// <summary>
        /// Identificador da campanha
        /// </summary>
        [Required(ErrorMessage = "Necessário informar o id da campanha")]
        public string CampaignId { get; set; }
    }
}
