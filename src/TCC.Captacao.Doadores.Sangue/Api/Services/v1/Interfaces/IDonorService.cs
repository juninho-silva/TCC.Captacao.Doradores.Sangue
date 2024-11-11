using Api.DTOs.v1.Donor;

namespace Api.Services.v1.Interfaces
{
    /// <summary>
    /// Interface da Camada Servico Doador
    /// </summary>
    public interface IDonorService
    {
        /// <summary>
        /// Responsavel por criar um usuário doador
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> Create(DonorRequest request);
        /// <summary>
        /// Responsavel por alterar um doador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> Update(string id, DonorRequest request);
        /// <summary>
        /// Responsavel por obter um doador por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DonorResponse> GetById(string id);
        /// <summary>
        /// Responsavel por obter doadores
        /// </summary>
        /// <returns></returns>
        Task<List<DonorResponse>> GetAll();
        /// <summary>
        /// Responsavel por deletar doador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(string id);
    }
}
