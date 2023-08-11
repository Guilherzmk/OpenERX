using OpenERX.Commons.Types.Phones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Phones
{
    public interface IPhoneRepository
    {
        Task<Phone> InsertPhoneAsync(Guid parentId, Phone phone);
        Task<Guid> DeletePhoneAsync(Guid parentId);
        Task<IList<Phone>> GetAllPhonesAsync(Guid parentId);
    }
}
