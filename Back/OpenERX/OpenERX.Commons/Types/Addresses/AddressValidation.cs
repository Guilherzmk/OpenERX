 
using OpenERX.Commons.Results;

namespace OpenERX.Commons.Types.Addresses
{
    public static class AddressValidation
    {
        public static bool Validate(this Address address, IResultService resultService)
        {
            var results = new List<ResultMessage>();

            results.AddMessages(AssertMessage.NotNullOrEmpty(address.Street, AddressMessages.InvalidStreet));
            results.AddMessages(AssertMessage.NotNullOrEmpty(address.City, AddressMessages.InvalidCity));
            results.AddMessages(AssertMessage.NotNullOrEmpty(address.State, AddressMessages.InvalidState));
            results.AddMessages(AssertMessage.NotNullOrEmpty(address.ZipCode, AddressMessages.InvalidZipCode));

            resultService.AddMessages(results);

            return results.Count == 0;
        }

    }
}
