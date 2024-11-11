using Api.DTOs.v1.Organization;
using Api.Extentions;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    /// <summary>
    /// Camada Controlador de Organizacao
    /// </summary>
    [Route("api/v1/organization")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="organizationService"></param>
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        /// <summary>
        /// Endpoint responsavel por criar organizacao
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] OrganizationRequest request)
        {
            var result = await _organizationService.Create(request);

            if (result is null)
                return this.Error(
                    messageError: new Dictionary<string, string> 
                    { 
                        { string.Empty, "Usuário já existente!" } 
                    }, 
                    code: StatusCodes.Status400BadRequest
                );

            return this.Success(result, StatusCodes.Status201Created);
        }

        /// <summary>
        /// Endpoint responsavel por obter as organizaçao
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _organizationService.GetAll();
            
            if (result is null)
            {
                return this.Success(
                    data: result,
                    code: StatusCodes.Status204NoContent
                );
            }

            return this.Success(result, code: StatusCodes.Status200OK);
        }

        /// <summary>
        /// Endpoint responsavel por obter a organizacao por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.Error(
                    messageError: new Dictionary<string, string>
                    {
                        { nameof(id), "Necessário informar o id" }
                    },
                    code: StatusCodes.Status400BadRequest
                );
            }

            var result = await _organizationService.GetById(id);

            if (result is null)
            {
                return this.Success(
                    data: result,
                    code: StatusCodes.Status204NoContent
                );
            }

            return this.Success(result, code: StatusCodes.Status200OK);
        }

        /// <summary>
        /// Endpoint responsavel por alterar a organizacao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] OrganizationRequest request)
        {
            if (string.IsNullOrEmpty(id))
            {
                return this.Error(
                    messageError: new Dictionary<string, string>
                    {
                        { nameof(id), "Necessário informar o id" }
                    },
                    code: StatusCodes.Status400BadRequest
                );
            }

            var ok = await _organizationService.Update(id, request);

            if (!ok)
            {
                return BadRequest();
            }

            return Ok(new { message = "Organização alterada com sucesso!" });
        }

        /// <summary>
        /// Endpoint responsavel por deletar a organizacao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("O id é obrigatório!");
            }

            var ok = await _organizationService.Delete(id);

            if (ok)
            {
                return Ok(new { message = "Deletado com sucesso!" });
            }

            return BadRequest(new { error = "Id informado não encontrado" });
        }
    }
}
