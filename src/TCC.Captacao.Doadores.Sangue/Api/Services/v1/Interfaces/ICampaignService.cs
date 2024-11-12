using Api.DTOs.v1.Campaign;
using Api.DTOs.v1.Campaign.Requests;

namespace Api.Services.v1.Interfaces
{
    /// <summary>
    /// Interface de Camada Servico Campanha
    /// </summary>
    public interface ICampaignService
    {
        /// <summary>
        /// Responsavel por criar campanha
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<CampaignResponse> Create(CampaignRequest request);
        /// <summary>
        /// Responsavel por alterar campanha
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<bool> Update(string id, CampaignRequest request);
        /// <summary>
        /// Responsavel por obter campanha por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<CampaignResponse> GetById(string id);
        /// <summary>
        /// Responsavel por obter campanhas
        /// </summary>
        /// <returns></returns>
        Task<List<CampaignResponse>> GetAll();
        /// <summary>
        /// Responsavel por deletar campanha
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(string id);
    }
}
