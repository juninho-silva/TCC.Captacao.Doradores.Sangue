using Api.DTOs.v1.Organization;

namespace Api.Services.v1.Interfaces
{
    /// <summary>
    /// Interface da Camada Servico Organizacao (Banco de Sangue)
    /// </summary>
    public interface IOrganizationService
    {
        /// <summary>
        /// Responsavel por criar o usuário organizacao (Banco de Sangue)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<OrganizationResponse> Create(OrganizationRequest request);
        /// <summary>
        /// Responsavel por alterar organizacao
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> Update(string id, OrganizationRequest request);
        /// <summary>
        /// Responsavel por obter organizacao por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrganizationResponse> GetById(string id);
        /// <summary>
        /// Responsavel por obter organizacoes
        /// </summary>
        /// <returns></returns>
        Task<List<OrganizationResponse>> GetAll();
        /// <summary>
        /// Responsavel por deletar organizacao
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(string id);
    }
}
