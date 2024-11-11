using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.DTOs.v1.Authentication
{
    public class AuthenticationRequest
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        [Required(ErrorMessage = "Necessário informar a senha")]
        public string Password { get; set; }
    }
}
