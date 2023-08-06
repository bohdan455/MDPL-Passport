namespace MDPL_Passport.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
        Task<bool> TryLogin(string username, string password);
    }
}