using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Api.Infrastructure.Data.Repositories.Campaign
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class CampaignRepository : BaseRepository<CampaignEntity>, ICampaignRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public CampaignRepository(IMongoDatabase database) : base("campaigns", database)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateAsync(CampaignEntity entity)
        {
            await AddAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(string id)
        {
            await DeleteAsync(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<CampaignEntity>> FindAllAsync()
        {
            return (await GetAllAsync()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CampaignEntity> FindOneAsync(string id)
        {
            return await GetByIdAsync(id);
        }
    }
}
