using Api.DTOs.v1.Authentication;
using Api.Infrastructure.Auth;
using Api.Infrastructure.Data.Repositories.User;
using Api.Services.v1.Interfaces;
using MongoDB.Driver;

namespace Api.Services.v1
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="tokenService"></param>
        /// <param name="logger"></param>
        public AuthService(
            IUserRepository userRepository,
            ITokenService tokenService,
            ILogger<AuthService> logger)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Generate Token
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<AuthenticationResponse> GenerateToken(AuthenticationRequest request)
        {
            try
            {
                Dictionary<string, string> details = new();

                var filterByUsernameOrEmail = Builders<UserEntity>.Filter.Or(
                    Builders<UserEntity>.Filter.Eq(user => user.Username, request.Username),
                    Builders<UserEntity>.Filter.Eq(user => user.Email, request.Email)
                );

                var user = (await _userRepository.FindAsync(filterByUsernameOrEmail))
                    .FirstOrDefault();

                if (user is null)
                {
                    details.Add(string.Empty, "Usuario não encontrado!");
                    return new()
                    {
                        Details = details
                    };
                }

                if (user.Password != request.Password)
                {
                    details.Add(nameof(user.Password), "Senha inválida!");
                    return new()
                    {
                        Details = details
                    };
                }

                return new()
                {
                    Token = _tokenService.GenerateToken(request.Username ?? request.Email)
                };
            }
            catch (Exception err)
            {
                _logger.LogError($"[{nameof(AuthService)}] - {err.Message}");
                throw;
            }
        }
    }
}
