using Api.DTOs.v1.Notification;
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
        /// 
        /// </summary>
        /// <param name="notificationService"></param>
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
        public IActionResult Send([FromRoute] NotificationRequest request)
        {
            _notificationService.ScheduleNotification(request);
            return Ok(new { message = "Notificação agendada com sucesso!" });
        }
    }
}
