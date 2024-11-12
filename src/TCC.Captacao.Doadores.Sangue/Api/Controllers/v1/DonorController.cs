using Api.DTOs.v1.Donor;
using Api.Extentions;
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
        /// Initializes a new instance of the <see cref="DonorController"/> class.
        /// </summary>
        /// <param name="donorService">The donor service.</param>
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
        [ProducesResponseType(typeof(CustomResponse<DonorResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Post([FromBody] DonorRequest request)
        {
            var result = await _donorService.Create(request);

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
        /// Endpoint responsavel por retornar todos os doadores
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<List<DonorResponse>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> Get()
        {
            var result = await _donorService.GetAll();

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
        /// Endpoint responsavel por buscar doador por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<DonorResponse>), StatusCodes.Status200OK)]
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

            var result = await _donorService.GetById(id);

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
        /// Endpoint responsavel por atualizar o doador
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
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] DonorRequest request)
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

            var result = await _donorService.Update(id, request);

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
        /// Endpoint responsavel por deletar doador
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

            var result = await _donorService.Delete(id);

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
