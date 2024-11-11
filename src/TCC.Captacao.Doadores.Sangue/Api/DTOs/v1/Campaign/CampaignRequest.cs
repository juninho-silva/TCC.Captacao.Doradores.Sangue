using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.DTOs.v1.Campaign.Requests
{
    public class CampaignRequest
    {
        [JsonPropertyName("title")]
        [Required(ErrorMessage = "Necessário informar o titulo")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        [Required(ErrorMessage = "Necessário informar a descrição")]
        public string Description { get; set; }

        [JsonPropertyName("bloodType")]
        [Required(ErrorMessage = "Necessário informar o tipo sanguíneo")]
        [BloodType]
        public string BloodType { get; set; }

        [JsonPropertyName("organizationId")]
        [Required(ErrorMessage = "Necessário informar o id da organização")]
        public string OrganizationId { get; set; }
    }
}
