using Api.DTOs.v1.Organization;
using Api.Infrastructure.Data.Repositories.Organization;
using Api.Infrastructure.Data.Repositories.User;
using Api.Services.v1.Interfaces;
using AutoMapper;
using MongoDB.Driver;

namespace Api.Services.v1
{
    /// <summary>
    /// Camada Servico Organizacao
    /// </summary>
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizationRepository _organizationRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<OrganizationService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Construtor Camada Servico Organizacao
        /// </summary>
        /// <param name="organizationRepository"></param>
        /// <param name="userRepository"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public OrganizationService(
            IOrganizationRepository organizationRepository,
            IUserRepository userRepository,
            ILogger<OrganizationService> logger,
            IMapper mapper)
        {
            _organizationRepository = organizationRepository;
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Responsavel por criar um usuário organizacao
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<OrganizationResponse> Create(OrganizationRequest request)
        {
            try
            {
                var newuser = await CreateUser(request);
                var organization = _mapper.Map<OrganizationEntity>(request);
                organization.UserId = newuser.Id;
                await _organizationRepository.CreateAsync(organization);

                return _mapper.Map<OrganizationResponse>(organization);
            }
            catch (ArgumentException err) when (err.Message.Contains("Usuário existente!"))
            {
                _logger.LogWarning($"[{nameof(OrganizationService)}] - {err.Message}");
                return null;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(OrganizationService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            try
            {
                var entity = await _organizationRepository.FindOneAsync(id);

                if (entity is null)
                {
                    return false;
                }

                await _organizationRepository.RemoveAsync(entity.Id);

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(OrganizationService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<OrganizationResponse>> GetAll()
        {
            try
            {
                var entities = await _organizationRepository.FindAllAsync();

                return _mapper.Map<List<OrganizationResponse>>(entities);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(OrganizationService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OrganizationResponse> GetById(string id)
        {
            try
            {
                var entity = await _organizationRepository.FindOneAsync(id);

                return _mapper.Map<OrganizationResponse>(entity);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(OrganizationService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> Update(string id, OrganizationRequest request)
        {
            try
            {
                var entity = await _organizationRepository.FindOneAsync(id);

                if (entity is null)
                {
                    return false;
                }

                await _organizationRepository.UpdateAsync(id, _mapper.Map(request, entity));

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(OrganizationService)}] - {err.Message}");
                throw;
            }
        }

        private async Task<UserEntity> CreateUser(OrganizationRequest donorUser)
        {
            var user = _mapper.Map<UserEntity>(donorUser.User);
            user.Email = donorUser.Contact.Email;

            var filterByEmail = Builders<UserEntity>.Filter.Eq(u => u.Email, user.Email);
            var filterByUsername = Builders<UserEntity>.Filter.Eq(u => u.Username, user.Username);

            var isUser = (await _userRepository.FindAsync(filterByEmail & filterByUsername)).Any();

            if (isUser)
            {
                throw new ArgumentException("Usuário existente!");
            }

            await _userRepository.CreateAsync(user);
            return user;
        }
    }
}
