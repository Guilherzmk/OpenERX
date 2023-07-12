
using OpenERX.Commons.Params;
using OpenERX.Commons.Results;
using OpenERX.Commons.Types.Results;
using OpenERX.Core.Shared.Types;

namespace OpenERX.Core.Customers
{
    public interface ICustomerService : IResultService
    {
        Task<CustomerResult> CreateAsync(CustomerParams createParams, string role);
        Task<CustomerResult> UpdateAsync(Guid id, CustomerParams updateParams, string role);
        Task<CustomerResult> UpdateStatusAsync(Guid id, UpdateStatusParams3 updateParams);
        Task<CountResult> DeleteAsync(IdParams deleteParams, string role);
        Task<CustomerResult> GetAsync(Guid id, string role);
        Task<IList<Customer>> Find(string role);
        Task<CustomerResult> StatusUpdate(Guid id, StatusType statusType);
    }
}
