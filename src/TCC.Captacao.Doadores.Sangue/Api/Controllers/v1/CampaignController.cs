using Api.DTOs.v1.Campaign.Requests;
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
        /// 
        /// </summary>
        /// <param name="campaingService"></param>
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
        public async Task<IActionResult> Post([FromBody] CampaignRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _campaignService.Create(request);

            return Created(nameof(Post), new { message = "Campanha criado com sucesso!" });
        }

        /// <summary>
        /// Endpoint responsavel por obter todas as campanhas
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _campaignService.GetAll());
        }

        /// <summary>
        /// Endpoint responsavel por buscar uma campanha por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("O id é obrigatório!");
            }

            var result = await _campaignService.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint responsavel por atualizar a campanha
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] CampaignRequest request)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("O id é obrigatório!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _campaignService.Update(id, request);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint responsavel por deletar a campanha
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

            var result = await _campaignService.Delete(id);

            if (result)
            {
                return Ok(new { message = "Deletado com sucesso!" });
            }

            return BadRequest(new { message = "Id informado não encontrado" });
        }
    }
}
