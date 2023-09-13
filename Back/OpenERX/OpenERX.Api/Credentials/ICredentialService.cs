using OpenERX.Commons.Credentials;
using OpenERX.Core.Users;

namespace OpenERX.WebAPI.Credentials
{
    public interface ICredentialService
    {
        Task<User> GetContextUser();
        Task<Credential> CreateCredential();
        Task<Guid> GetContextProfile();
    }
}
