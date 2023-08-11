 
namespace OpenERX.Commons.Types.Phones
{
    public partial class Phone
    {
        public static Phone Create(PhoneParams createParams)
        {
            return new Phone().SetParams(createParams);
        }

        public static IList<Phone> CreateList(IList<PhoneParams> createParams)
        {
            var list = new List<Phone>();

            if (createParams == null)
                return list;

            foreach (var item in createParams)
            {
                if (string.IsNullOrWhiteSpace(item.Number)) continue;

                list.Add(Create(item));
            }

            return list;
        }
    }
}