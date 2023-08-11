 
namespace OpenERX.Commons.Types.Sites
{
    public partial class Site
    {
        public static Site Create(SiteParams createParams)
        {
            return new Site().SetParams(createParams);
        }

        public static IList<Site> CreateList(IList<SiteParams> createParams)
        {
            var list = new List<Site>();

            if (createParams == null)
                return list;

            list.AddRange(createParams.Select(Create));

            return list;
        }
    }
}
