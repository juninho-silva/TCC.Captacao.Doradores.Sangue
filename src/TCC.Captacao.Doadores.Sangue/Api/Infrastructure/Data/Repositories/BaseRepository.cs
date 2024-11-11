using MongoDB.Driver;
using System.Diagnostics.CodeAnalysis;

namespace Api.Infrastructure.Data.Repositories
{
    /// <summary>
    /// Camada Repositorio
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    [ExcludeFromCodeCoverage]
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _collection;

        /// <summary>
        /// Construtor Camada Repositorio
        /// </summary>
        /// <param name="collectionName"></param>
        /// <param name="database"></param>
        public BaseRepository(string collectionName, IMongoDatabase database)
        {
            _collection = database.GetCollection<TEntity>(collectionName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            await _collection.InsertOneAsync(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(string id)
        {
            await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", id));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _collection.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> WhereAsync(FilterDefinition<TEntity> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _collection.Find(Builders<TEntity>.Filter.Eq("Id", id)).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(string id, TEntity entity)
        {
            await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("Id", id), entity);
        }
    }
}
