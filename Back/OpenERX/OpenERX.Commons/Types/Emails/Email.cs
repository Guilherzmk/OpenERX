 
namespace OpenERX.Commons.Types.Emails
{
    public partial class Email
    {
        public Guid Id { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Address { get; set; }
 
        public string Note { get; set; }
 

        public Email()
        {
            this.Id = Guid.NewGuid(); 
        }
 

        public override string ToString()
        {
            return this.Address;
        }
    }
}
