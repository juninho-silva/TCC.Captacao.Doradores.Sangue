using System.Text.Json.Serialization;

namespace Api.DTOs.v1.Authentication
{
    /// <summary>
    /// Authentication Response
    /// </summary>
    public class AuthenticationResponse
    {
        /// <summary>
        /// Detalhes
        /// </summary>
        [JsonIgnore]
        public Dictionary<string, string> Details { get; set; }
        /// <summary>
        /// Token
        /// </summary>
        public string Token { get; set; }
    }
}
