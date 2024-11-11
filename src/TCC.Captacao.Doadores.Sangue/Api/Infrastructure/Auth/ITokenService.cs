namespace Api.Infrastructure.Auth
{
    /// <summary>
    /// 
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        string GenerateToken(string username);
    }
}
