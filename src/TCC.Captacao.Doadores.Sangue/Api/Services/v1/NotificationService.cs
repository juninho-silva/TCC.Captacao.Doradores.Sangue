using Api.DTOs.v1.Notification;
using Api.Infrastructure.Data.Repositories.Campaign;
using Api.Infrastructure.Data.Repositories.Donor;
using Api.Infrastructure.Data.Repositories.Organization;
using Api.Infrastructure.Smtp;
using Api.Services.v1.Interfaces;

namespace Api.Services.v1
{
    /// <summary>
    /// Camada Servico Notificacao
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly IEmailService _emailService;
        private readonly IDonorRepository _donorRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IOrganizationRepository _organizationRepository;
        private readonly ILogger<NotificationService> _logger;

        /// <summary>
        ///
        /// </summary>
        /// <param name="emailService"></param>
        /// <param name="donorRepository"></param>
        /// <param name="campaignRepository"></param>
        /// <param name="organizationRepository"></param>
        /// <param name="logger"></param>
        public NotificationService(
            IEmailService emailService,
            IDonorRepository donorRepository,
            ICampaignRepository campaignRepository,
            IOrganizationRepository organizationRepository,
            ILogger<NotificationService> logger)
        {
            _donorRepository = donorRepository;
            _campaignRepository = campaignRepository;
            _organizationRepository = organizationRepository;
            _emailService = emailService;
            _logger = logger;
        }

        /// <summary>
        /// Responsável por agendar o envio para notifcar as campanha aos doadores
        /// </summary>
        /// <param name="request"></param>
        public void ScheduleNotification(NotificationRequest request)
        {
            Task.Run(async () =>
            {
                try
                {
                    var campaign = await _campaignRepository.FindOneAsync(request.CampaignId);

                    if (campaign is null)
                    {
                        _logger.LogWarning($"[{nameof(NotificationService)}] - campaign {request.CampaignId} not found");
                        return;
                    }

                    var organization = await _organizationRepository.FindOneAsync(campaign.OrganizationId);

                    if (organization is null)
                    {
                        _logger.LogWarning($"[{nameof(NotificationService)}] - organization not found");
                        return;
                    }

                    var donors = (await _donorRepository.FindAllAsync())?
                        .Where(d => d.BloodType.Equals(campaign.BloodType))?
                        .ToList();

                    if (donors is null || donors.Count == 0)
                    {
                        _logger.LogWarning($"[{nameof(NotificationService)}] - without donors");
                        return;
                    }

                    foreach (var donor in donors)
                    {
                        await _emailService.SendAsync(donor.Contact.Email, campaign.Title, campaign.Description);
                        await Task.Delay(1);
                    }
                }
                catch (Exception err)
                {
                    _logger.LogError($"[{nameof(NotificationService)}] - {err.Message}");
                    throw;
                }
            });
        }
    }
}
