using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Api.Infrastructure.Data.Repositories.Organization
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class OrganizationRepository : BaseRepository<OrganizationEntity>, IOrganizationRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public OrganizationRepository(IMongoDatabase database) : base("bloodBanks", database)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateAsync(OrganizationEntity entity)
        {
            await AddAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrganizationEntity>> FindAllAsync()
        {
            return (await GetAllAsync()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrganizationEntity> FindOneAsync(string id)
        {
            return await GetByIdAsync(id);
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
    }
}
