 
namespace OpenERX.Commons.Types.Sites
{
    public class SiteParams
    {
        public int? TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Address { get; set; }
        public string Note { get; set; } 
 
        public bool IsValid()
        {
            return SiteFunctions.IsValid(this.Address);
        }
    }
}

