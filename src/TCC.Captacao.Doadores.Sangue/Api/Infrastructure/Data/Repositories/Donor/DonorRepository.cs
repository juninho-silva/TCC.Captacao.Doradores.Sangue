using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Api.Infrastructure.Data.Repositories.Donor
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class DonorRepository : BaseRepository<DonorEntity>, IDonorRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public DonorRepository(IMongoDatabase database) : base("donors", database)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateAsync(DonorEntity entity)
        {
            await AddAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<DonorEntity>> FindAllAsync()
        {
            return (await GetAllAsync()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DonorEntity> FindOneAsync(string id)
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
