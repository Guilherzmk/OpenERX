 
using OpenERX.Commons.Credentials;
using OpenERX.Commons.Results;

namespace OpenERX.Core.Customers
{
    public static class CustomerUpdate
    {
        public static async Task<Customer> UpdateAsync(
        this Customer _this,
        CustomerParams updateParams,
        Credential credential, 
        IResultService resultService)
        {
            await _this.SetParamsAsync(
            updateParams,
            credential, 
            resultService);

            //_this.RecordUpdate(credential);
            return _this;
        }
    }
}
