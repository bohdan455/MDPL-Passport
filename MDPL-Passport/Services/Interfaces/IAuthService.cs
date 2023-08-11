namespace MDPL_Passport.Services
{
    public interface IAuthService
    {
        Task<bool> IsAuthenticated();
        Task Logout();
        Task<bool> TryLogin(string username, string password);
    }
}