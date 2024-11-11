using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Api.Infrastructure.Data.Repositories.User
{
    /// <summary>
    /// 
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="database"></param>
        public UserRepository(IMongoDatabase database) : base("users", database)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task CreateAsync(UserEntity entity)
        {
            await AddAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserEntity>> FindAllAsync()
        {
            return (await GetAllAsync()).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<List<UserEntity>> FindAsync(FilterDefinition<UserEntity> entity)
        {
            return (await WhereAsync(entity)).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserEntity> FindOneAsync(string id)
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
