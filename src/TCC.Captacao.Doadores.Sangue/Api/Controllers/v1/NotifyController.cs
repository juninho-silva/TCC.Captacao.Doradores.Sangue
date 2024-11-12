using Api.DTOs.v1.Donor;
using Api.DTOs.v1.Notification;
using Api.Extentions;
using Api.Services.v1.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.v1
{
    /// <summary>
    /// Camada Controlador de Notificacao
    /// </summary>
    [Route("api/v1/notify")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="NotifyController"/> class.
        /// </summary>
        /// <param name="notificationService">The notification service.</param>
        public NotifyController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        /// <summary>
        /// Endpoint responsavel por notificar por email
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("email")]
        [Authorize]
        [ProducesResponseType(typeof(CustomResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(CustomResponse<>), StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult Send([FromRoute] NotificationRequest request)
        {
            _notificationService.ScheduleNotification(request);
            return this.Success(true, StatusCodes.Status200OK);
        }
    }
}
