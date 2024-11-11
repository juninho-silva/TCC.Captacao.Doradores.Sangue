namespace Api.Infrastructure.Data.Repositories.Organization
{
    public interface IOrganizationRepository
    {
        Task CreateAsync(OrganizationEntity entity);
        Task UpdateAsync(string id, OrganizationEntity entity);
        Task RemoveAsync(string id);
        Task<List<OrganizationEntity>> FindAllAsync();
        Task<OrganizationEntity> FindOneAsync(string id);
    }
}
