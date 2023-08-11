 

namespace OpenERX.Commons.Types.Fields
{
    public partial class DataField
    {
        public static DataField Create(DataFieldParams createParams)
        {
            return new DataField().SetParams(createParams);
        }

        public static IList<DataField> CreateList(IList<DataFieldParams> createParams)
        {
            var list = new List<DataField>();

            if (createParams == null)
                return list;

            foreach (var item in createParams)
            {
                list.Add(Create(item));
            }

            return list;
        }
    }
}