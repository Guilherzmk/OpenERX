 
namespace OpenERX.Core.Customers
{
public class CustomerSupport
{
public IEnumerable<CustomerStatus> Status => CustomerStatus.GetAll();
public IEnumerable<CustomerType> Types => CustomerType.GetAll();
}
}
