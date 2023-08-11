 
namespace OpenERX.Commons.Types.Emails
{
    public class EmailParams
    {
        public int? TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Address { get; set; }
        public string Note { get; set; } 
 
        public bool IsValid()
        {
            return EmailFunctions.IsValid(this.Address);
        }
    }
}

