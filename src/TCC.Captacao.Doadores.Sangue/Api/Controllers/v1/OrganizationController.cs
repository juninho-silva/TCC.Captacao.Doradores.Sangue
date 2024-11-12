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
        [ProducesResponseType(typeof(CustomResponse<OrganizationResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
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
        /// Endpoint responsavel por obter as organizaçoes
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<List<OrganizationResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
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
        [ProducesResponseType(typeof(CustomResponse<OrganizationResponse>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
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
        [ProducesResponseType(typeof(CustomResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
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

            var result = await _organizationService.Update(id, request);

            if (!result)
            {
                return this.Error(
                    messageError: new Dictionary<string, string>
                    {
                        { nameof(id), "Id informado não encontrado" }
                    },
                    code: StatusCodes.Status404NotFound
                );
            }

            return this.Success(
                data: result,
                code: StatusCodes.Status200OK
            );
        }

        /// <summary>
        /// Endpoint responsavel por deletar a organizacao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                this.Error(
                    messageError: new Dictionary<string, string>
                    {
                        { nameof(id), "Necessário informar o id" }
                    },
                    code: StatusCodes.Status400BadRequest
                );
            }

            var result = await _organizationService.Delete(id);

            if (result)
            {
                return this.Success(
                    data: result,
                    code: StatusCodes.Status200OK
                );
            }

            return this.Error(
                messageError: new Dictionary<string, string>
                {
                    { nameof(id), "Id informado não encontrado" }
                },
                code: StatusCodes.Status404NotFound
            );
        }
    }
}
