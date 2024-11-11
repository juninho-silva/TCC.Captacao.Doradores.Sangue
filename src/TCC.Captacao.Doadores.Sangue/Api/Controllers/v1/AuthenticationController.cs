using Api.DTOs.v1.Authentication;
using Api.Extentions;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    /// <summary>
    /// Camada Controllador da Autenticação
    /// </summary>
    [Route("api/v1/authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="service"></param>
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
        public async Task<IActionResult> GetToken([FromBody] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return this.Error(
                    modelStateDictionary: ModelState,
                    code: StatusCodes.Status400BadRequest
                );
            }

            var result = await _authService.GenerateToken(request);

            if (string.IsNullOrEmpty(result.Token))
                return this.Error(result.Details, StatusCodes.Status401Unauthorized);

            return this.Success(result, StatusCodes.Status200OK);
        }
    }
}
