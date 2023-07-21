using OpenERX.Commons.Results;
using OpenERX.Core.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles
{
    public interface IProfileService : IResultService
    {
        Task<Profile> CreateAsync(ProfileParams profile, Guid role);
        Task<IList<Profile>> Find(Guid profileId);
        Task<Profile> GetAsync(Guid id);
    }
}
