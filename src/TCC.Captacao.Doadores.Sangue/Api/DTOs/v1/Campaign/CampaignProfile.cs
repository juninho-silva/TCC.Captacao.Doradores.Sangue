using Api.DTOs.v1.Campaign.Requests;
using Api.Infrastructure.Data.Repositories.Campaign;
using AutoMapper;

namespace Api.DTOs.v1.Campaign
{
    public class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<CampaignRequest, CampaignEntity>();
            CreateMap<CampaignEntity, CampaignResponse>();
        }
    }
}
