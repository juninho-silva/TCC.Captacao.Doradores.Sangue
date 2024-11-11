using Api.DTOs.v1.Donor;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    /// <summary>
    /// Camada Controlador de Doador
    /// </summary>
    [Route("api/v1/donor")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="donorService"></param>
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }

        /// <summary>
        /// Endpoint responsavel por criar doador
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost()]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] DonorRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _donorService.Create(request);

            return Created(nameof(Post), new { message = "Doador criado com sucesso!" });
        }

        /// <summary>
        /// Endpoint responsavel por retornar todos os doadores
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

            return Ok(await _donorService.GetAll());
        }

        /// <summary>
        /// Endpoint responsavel por buscar doador por ID
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

            var result = await _donorService.GetById(id);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint responsavel por atualizar o doador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] DonorRequest request)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("O id é obrigatório!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _donorService.Update(id, request);

            return Ok(result);
        }

        /// <summary>
        /// Endpoint responsavel por deletar doador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest(new { error = "Necessário informar o id" });
            }

            var result = await _donorService.Delete(id);

            if (result)
            {
                return Ok(new { message = "Deletado com sucesso!" });
            }

            return BadRequest(new { error = "Id informado não encontrado" });
        }
    }
}
