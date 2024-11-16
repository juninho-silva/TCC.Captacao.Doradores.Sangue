using Api.DTOs.v1.Campaign;
using Api.DTOs.v1.Campaign.Requests;
using Api.Extentions;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    /// <summary>
    /// Camada Controlador de Campanha
    /// </summary>
    [Route("api/v1/campaign")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _campaignService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignController"/> class.
        /// </summary>
        /// <param name="campaingService">The campaing service.</param>
        public CampaignController(ICampaignService campaingService)
        {
            _campaignService = campaingService;
        }

        /// <summary>
        /// Endpoint responsavel criar a campanha
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<CampaignResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] CampaignRequest request)
        {
            var result = await _campaignService.Create(request);

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
        /// Endpoint responsavel por obter todas as campanhas
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<List<CampaignResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status204NoContent)]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var result = await _campaignService.GetAll();

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
        /// Endpoint responsavel por buscar uma campanha por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<CampaignResponse>), StatusCodes.Status200OK)]
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

            var result = await _campaignService.GetById(id);

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
        /// Endpoint responsavel por atualizar a campanha
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
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] CampaignRequest request)
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

            var result = await _campaignService.Update(id, request);

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
        /// Endpoint responsavel por deletar a campanha
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

            var result = await _campaignService.Delete(id);

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
