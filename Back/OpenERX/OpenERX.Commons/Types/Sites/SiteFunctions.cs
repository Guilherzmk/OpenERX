using System.Text;

namespace OpenERX.Commons.Types.Sites
{
    public static class SiteFunctions
    {
        public static string Format(string site, string typeName)
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(site))
            {
                sb.Append(site.ToUpper());
            }

            if (!string.IsNullOrWhiteSpace(typeName))
            {
                sb.Append(" (" + typeName.ToUpper() + ")");
            }

            return sb.ToString();
        }

        public static bool IsValid(Site site)
        {
            return IsValid(site?.Address);
        }

        public static bool IsValid(string site)
        {
            return !string.IsNullOrWhiteSpace(site);
        }

    }
}
