namespace MDPL_Passport.Services
{
    public interface IEncryptingService
    {
        string DecryptString(string cipherText);
        string EncryptString(string plainText);
    }
}