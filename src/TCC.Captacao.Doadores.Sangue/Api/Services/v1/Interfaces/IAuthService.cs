using Api.DTOs.v1.Authentication;

namespace Api.Services.v1.Interfaces
{
    /// <summary>
    /// Interface da Camada Servico Autenticacao
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Responsavel por generar o token de usuario
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<AuthenticationResponse> GenerateToken(AuthenticationRequest request);
    }
}
