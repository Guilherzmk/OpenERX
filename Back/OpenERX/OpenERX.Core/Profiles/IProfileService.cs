using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles
{
    public interface IProfileService
    {
        Task<Profile> CreateAsync(Guid id, Profile profile);
        Task<Profile> GetAsync(Guid id);
    }
}
