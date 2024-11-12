using Api.DTOs.v1.Donor;
using Api.Infrastructure.Data.Repositories.Donor;
using Api.Infrastructure.Data.Repositories.User;
using Api.Services.v1.Interfaces;
using AutoMapper;
using MongoDB.Driver;

namespace Api.Services.v1
{
    /// <summary>
    /// Camada Servico Doador
    /// </summary>
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<DonorService> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DonorService"/> class.
        /// </summary>
        /// <param name="donorRepository">The donor repository.</param>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="mapper">The mapper.</param>
        public DonorService(
            IDonorRepository donorRepository,
            IUserRepository userRepository,
            ILogger<DonorService> logger,
            IMapper mapper)
        {
            _donorRepository = donorRepository;
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <summary>
        /// Responsavel por criar um novo usuario doador
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DonorResponse> Create(DonorRequest request)
        {
            try
            {
                var newuser = await CreateUser(request);
                var donor = _mapper.Map<DonorEntity>(request);
                donor.UserId = newuser.Id;
                await _donorRepository.CreateAsync(donor);

                return _mapper.Map<DonorResponse>(donor);
            }
            catch (ArgumentException err) when (err.Message.Contains("Usuário existente!"))
            {
                _logger.LogWarning($"[{nameof(CampaignService)}] - {err.Message}");
                return null;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por deletar um doador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> Delete(string id)
        {
            try
            {
                var entity = await _donorRepository.FindOneAsync(id);
                if (entity is null)
                    return false;
                await _donorRepository.RemoveAsync(entity.Id);

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por buscar todos os doadores
        /// </summary>
        /// <returns></returns>
        public async Task<List<DonorResponse>> GetAll()
        {
            try
            {
                var donors = await _donorRepository.FindAllAsync();

                return _mapper.Map<List<DonorResponse>>(donors);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por buscar um doador por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DonorResponse> GetById(string id)
        {
            try
            {
                var donor = await _donorRepository.FindOneAsync(id);

                return _mapper.Map<DonorResponse>(donor);
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        /// <summary>
        /// Responsavel por atualizar o doador
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<bool> Update(string id, DonorRequest request)
        {
            try
            {
                var entity = await _donorRepository.FindOneAsync(id);

                if (entity is null)
                {
                    return false;
                }

                await _donorRepository.UpdateAsync(id, _mapper.Map(request, entity));

                return true;
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(CampaignService)}] - {err.Message}");
                throw;
            }
        }

        private async Task<UserEntity> CreateUser(DonorRequest donorUser)
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
