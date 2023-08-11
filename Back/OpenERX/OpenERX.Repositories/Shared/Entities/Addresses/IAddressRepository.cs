using OpenERX.Commons.Types.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Addresses
{
    public interface IAddressRepository
    {
        Task<Address> InsertAddressAsync(Guid parentId, Address address);
        Task<Guid> DeleteAddressAsync(Guid parentId);
        Task<IList<Address>> GetAllAddressesAsync(Guid parentId);

    }
}
