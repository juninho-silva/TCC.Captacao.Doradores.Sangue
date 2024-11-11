﻿using Api.DTOs.v1.Campaign;
using Api.DTOs.v1.Campaign.Requests;
using Api.Infrastructure.Data.Repositories.Campaign;
using Api.Infrastructure.Data.Repositories.Donor;
using Api.Infrastructure.Smtp;
using Api.Services.v1.Interfaces;
using AutoMapper;

namespace Api.Services.v1
{
    public class CampaignService : ICampaignService
    {
        private readonly IEmailService _emailService;
        private readonly ILogger<CampaignService> _logger;
        private readonly IDonorRepository _donorRepository;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IMapper _mapper;

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

        public async Task<bool> Create(CampaignRequest request)
        {
            try
            {
                CampaignEntity entity = _mapper.Map<CampaignEntity>(request);

                await _campaignRepository.CreateAsync(entity);

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

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