 
namespace OpenERX.Commons.Types.Addresses
{
    public class AddressParams
    {
        public int? TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Prefix { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        
        public string Note { get; set; } 
 
        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(this.Street) ||
                   !string.IsNullOrWhiteSpace(this.City) ||
                   !string.IsNullOrWhiteSpace(this.State);
        }
    }
}

