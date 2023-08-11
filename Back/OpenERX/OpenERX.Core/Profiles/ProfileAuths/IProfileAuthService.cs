using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles.ProfileAuths
{
    public interface IProfileAuthService
    {
        Task<ProfileAuth> CreateAsync(Guid id, ProfileAuth profileAuth);
    }
}
