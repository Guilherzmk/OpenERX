using OpenERX.Core.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.SignIns
{
    public interface ISignInRepository
    {
        Task<User> Get(string accessKey);
    }
}
