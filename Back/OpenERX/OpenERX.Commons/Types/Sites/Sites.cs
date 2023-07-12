 
namespace OpenERX.Commons.Types.Sites
{
    public partial class Site
    {
        public Guid Id { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Address { get; set; }
 
        public string Note { get; set; } 

        public Site()
        {
            this.Id = Guid.NewGuid(); 
        }
 
        public override string ToString()
        {
            return this.Address;
        }
    }
}
