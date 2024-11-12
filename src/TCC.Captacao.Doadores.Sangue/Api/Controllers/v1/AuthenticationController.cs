using Api.DTOs.v1.Authentication;
using Api.Extentions;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    /// <summary>
    /// Camada Controllador da Autenticacao
    /// </summary>
    /// <seealso cref="ControllerBase" />
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationController"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public AuthenticationController(IAuthService service)
        {
            _authService = service;
        }

        /// <summary>
        /// Endpoint responsavel em gerar o token de usuário
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(CustomResponse<AuthenticationResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status401Unauthorized)]
        [Produces("application/json")]
        public async Task<IActionResult> GetToken([FromBody] AuthenticationRequest request)
        {
            var result = await _authService.GenerateToken(request);

            if (string.IsNullOrEmpty(result.Token))
                return this.Error(result.Details, StatusCodes.Status401Unauthorized);

            return this.Success(result, StatusCodes.Status200OK);
        }
    }
}
