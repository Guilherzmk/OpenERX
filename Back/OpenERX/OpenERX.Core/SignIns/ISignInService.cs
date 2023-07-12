using OpenERX.Commons.Results;
using OpenERX.Core.Users;

namespace OpenERX.Core.SignIns;

public interface ISignInService: IResultService
{
    Task<UserResult> SignInAsync(SignInParams @params);
}