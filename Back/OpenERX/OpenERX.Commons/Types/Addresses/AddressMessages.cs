 
using OpenERX.Commons.Languages;
using OpenERX.Commons.Results;

namespace OpenERX.Commons.Types.Addresses
{
    public class AddressMessages
    {
        public static ResultMessage InvalidAddress = new(ResultMessageTypes.Error, Words.InvalidAddress);
        public static ResultMessage InvalidStreet = new(ResultMessageTypes.Error, Words.InvalidAddress);
        public static ResultMessage InvalidNumber = new(ResultMessageTypes.Error, Words.InvalidNumbers);
        public static ResultMessage InvalidCity = new(ResultMessageTypes.Error, Words.InvalidCity);
        public static ResultMessage InvalidState = new(ResultMessageTypes.Error, Words.InvalidState);
        public static ResultMessage InvalidZipCode = new(ResultMessageTypes.Error, Words.InvalidZipCode);
    }
}

