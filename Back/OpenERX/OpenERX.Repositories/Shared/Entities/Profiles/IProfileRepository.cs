using OpenERX.Core.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Profiles
{
    public interface IProfileRepository
    {
        Task<Profile> InsertProfileAsync(Profile profile);
        Task<Profile> Get(Guid id);
        Task<IList<Profile>> Find();
    }
}
