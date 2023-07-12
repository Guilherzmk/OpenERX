 

namespace OpenERX.Commons.Types.Addresses
{
    public partial class Address
    {
        public static Address Create(AddressParams createParams)
        {
            return new Address().SetParams(createParams);
        }

        public static IList<Address> CreateList(IList<AddressParams> createParams)
        {
            var list = new List<Address>();

            if (createParams == null)
                return list;

            list.AddRange(createParams.Select(Create));

            return list;
        }
    }
}