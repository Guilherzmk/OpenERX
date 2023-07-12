
using OpenERX.Core.Shared.Types;

namespace OpenERX.Core.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> InsertAsync(Customer customer);
        Task InsertManyAsync(IList<Customer> customers);
        Task<long> UpdateAsync(Customer customer);
        Task<long> DeleteAsync(Guid id);
        Task<Customer> GetAsync(Guid id);
        Task<long> StatusUpdateAsync(Guid id, StatusType status);
        Task<IList<Customer>> FindAsync();
        Task<Customer> GetAsync(int accountCode, Guid id);
    }
}
