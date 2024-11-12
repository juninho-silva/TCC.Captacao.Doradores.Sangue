using Api.DTOs.v1.Campaign;
using Api.DTOs.v1.Campaign.Requests;
using Api.Infrastructure.Data.Repositories.Campaign;
using Api.Infrastructure.Data.Repositories.Donor;
using Api.Infrastructure.Smtp;
using Api.Services.v1.Interfaces;
using AutoMapper;

namespace Api.Services.v1
{
    /// <summary>
    /// Camada Servico Campaign
    /// </summary>
    /// <seealso cref="ICampaignService" />
    public class CampaignService : ICampaignService
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<CampaignService> _logger;
        private readonly IDonorRepository _donorRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CampaignService"/> class.
        /// </summary>
        /// <param name="donorRepository">The donor repository.</param>
        /// <param name="campaignRepository">The campaign repository.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="mapper">The mapper.</param>
        public CampaignService(
            IDonorRepository donorRepository,
            ICampaignRepository campaignRepository,
            ILogger<CampaignService> logger,
            IConfiguration configuration,
            IMapper mapper)
        {
            _emailService = new EmailService(configuration);
            _donorRepository = donorRepository;
            _campaignRepository = campaignRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Responsavel por criar campanha
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<CampaignResponse> Create(CampaignRequest request)
        {
            try
            {
                CampaignEntity entity = _mapper.Map<CampaignEntity>(request);

                await _campaignRepository.CreateAsync(entity);

                return _mapper.Map<CampaignResponse>(entity);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por alterar campanha
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> Update(string id, CampaignRequest request)
        {
            try
            {
                var campaign = await _campaignRepository.FindOneAsync(id);

                if (campaign is null)
                {
                    _logger.LogWarning("Campanha não encontrada!");
                    return false;
                }

                var entity = _mapper.Map(campaign, request);

                await _campaignRepository.UpdateAsync(id, campaign);

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por obter campanha por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CampaignResponse> GetById(string id)
        {
            try
            {
                var campaign = await _campaignRepository.FindOneAsync(id);

                return _mapper.Map<CampaignResponse>(campaign);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por obter campanhas
        /// </summary>
        /// <returns></returns>
        public async Task<List<CampaignResponse>> GetAll()
        {
            try
            {
                var campaigns = await _campaignRepository.FindAllAsync();

                return _mapper.Map<List<CampaignResponse>>(campaigns);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por deletar campanha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            try
            {
                var campaign = await _campaignRepository.FindOneAsync(id);

                if (campaign is null)
                {
                    return false;
                }

                await _campaignRepository.RemoveAsync(id);

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }
    }
}
