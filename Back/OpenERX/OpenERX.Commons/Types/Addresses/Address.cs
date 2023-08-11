 

namespace OpenERX.Commons.Types.Addresses
{
    public partial class Address
    {
        public Guid Id { get; set; }
        public string ParentType { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Prefix { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string District { get; set; }
        public string City { get; set; }
 
        private string _state;
        public string State
        {
            get
            {
                if (string.IsNullOrWhiteSpace(this._state) || this._state.Length < 2)
                    return null;

                return this._state[..2];
            }
            set => this._state = value;
        }


        public string Country { get; set; }
        public string ZipCode { get; set; }
 
        public int? Index { get; set; }
        public string Note { get; set; }
 
  

        public Address()
        {
            this.Id = Guid.NewGuid(); 
        }
  
    }
}
