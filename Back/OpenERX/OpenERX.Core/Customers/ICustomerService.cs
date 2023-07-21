
using OpenERX.Commons.Params;
using OpenERX.Commons.Results;
using OpenERX.Commons.Types.Results;
using OpenERX.Core.Shared.Types;

namespace OpenERX.Core.Customers
{
    public interface ICustomerService : IResultService
    {
        Task<CustomerResult> CreateAsync(CustomerParams createParams, Guid profileId);
        Task<CustomerResult> UpdateAsync(Guid id, CustomerParams updateParams, Guid profileId);
        Task<CustomerResult> UpdateStatusAsync(Guid id, UpdateStatusParams3 updateParams);
        Task<CountResult> DeleteAsync(IdParams deleteParams, Guid profileId);
        Task<CustomerResult> GetAsync(Guid id, Guid profileId);
        Task<IList<Customer>> Find(Guid profileId);
        Task<CustomerResult> StatusUpdate(Guid id, StatusType statusType);
    }
}
