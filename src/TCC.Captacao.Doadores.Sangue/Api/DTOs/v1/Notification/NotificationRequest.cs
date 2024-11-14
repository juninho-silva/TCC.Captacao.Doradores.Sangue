using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [JsonPropertyName("campaignId")]
        public string CampaignId { get; set; }
    }
}
