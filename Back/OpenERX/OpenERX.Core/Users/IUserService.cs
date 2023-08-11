using OpenERX.Commons.Types.Results;
using OpenERX.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Users
{
    public interface IUserService
    {
        Task<UserResult> CreateAsync(UserParams createParams);
        Task<UserResult> LoginAsync(string accessKey, string password);


    }
}
