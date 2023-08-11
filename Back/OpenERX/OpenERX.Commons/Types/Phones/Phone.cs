 
namespace OpenERX.Commons.Types.Phones
{
    public partial class Phone
    {
        public Guid Id { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string CountryCode { get; set; }
        public string Number { get; set; }
        public string Note { get; set; } 
 
        public Phone()
        {
            this.Id = Guid.NewGuid(); 
        }
         

        public override string ToString()
        {
            return this.Number;
        }
    }
}
