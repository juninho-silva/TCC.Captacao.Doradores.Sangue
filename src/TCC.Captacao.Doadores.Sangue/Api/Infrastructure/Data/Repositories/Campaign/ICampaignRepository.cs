namespace Api.Infrastructure.Data.Repositories.Campaign
{
    public interface ICampaignRepository
    {
        Task CreateAsync(CampaignEntity entity);
        Task UpdateAsync(string id, CampaignEntity entity);
        Task RemoveAsync(string id);
        Task<List<CampaignEntity>> FindAllAsync();
        Task<CampaignEntity> FindOneAsync(string id);
    }
}
