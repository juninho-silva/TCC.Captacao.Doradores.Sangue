using MongoDB.Driver;

namespace Api.Infrastructure.Data.Repositories.User
{
    public interface IUserRepository
    {
        Task CreateAsync(UserEntity entity);
        Task UpdateAsync(string id, UserEntity entity);
        Task RemoveAsync(string id);
        Task<List<UserEntity>> FindAllAsync();
        Task<List<UserEntity>> FindAsync(FilterDefinition<UserEntity> entity);
        Task<UserEntity> FindOneAsync(string id);
    }
}
