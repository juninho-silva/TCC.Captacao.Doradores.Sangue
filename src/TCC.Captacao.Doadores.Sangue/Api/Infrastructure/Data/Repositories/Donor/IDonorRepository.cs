namespace Api.Infrastructure.Data.Repositories.Donor
{
    public interface IDonorRepository
    {
        Task CreateAsync(DonorEntity entity);
        Task UpdateAsync(string id, DonorEntity entity);
        Task RemoveAsync(string id);
        Task<List<DonorEntity>> FindAllAsync();
        Task<DonorEntity> FindOneAsync(string id);
    }
}
