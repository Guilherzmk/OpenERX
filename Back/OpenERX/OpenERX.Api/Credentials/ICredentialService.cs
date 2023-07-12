using OpenERX.Core.Users;

namespace OpenERX.WebAPI.Credentials
{
    public interface ICredentialService
    {
        Task<User> GetContextUser();
        Task<string> GetContextProfile();
    }
}
