using OpenERX.Core.Profiles.ProfileAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Profiles.ProfileAuths
{
    public interface IProfileAuthRepository
    {
        Task<ProfileAuth> InsertProfileAuthAsync(Guid parentId, string parentType, ProfileAuth profile);
        Task<bool> Verification(string role, string authorization);
    }
}
