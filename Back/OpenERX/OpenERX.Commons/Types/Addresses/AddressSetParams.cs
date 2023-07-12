 
namespace OpenERX.Commons.Types.Addresses
{
    public static class AddressSetParams
    {
        public static Address SetParams(
        this Address _this,
        AddressParams modelParams)
        {
            if (modelParams.TypeCode != null)
                _this.TypeCode = modelParams.TypeCode ?? 0;

            if (modelParams.TypeName != null)
                _this.TypeName = modelParams.TypeName;

            if (modelParams.Prefix != null)
                _this.Prefix = modelParams.Prefix;

            if (modelParams.Street != null)
                _this.Street = modelParams.Street;

            if (modelParams.Number != null)
                _this.Number = modelParams.Number;

            if (modelParams.Complement != null)
                _this.Complement = modelParams.Complement;

            if (modelParams.District != null)
                _this.District = modelParams.District;

            if (modelParams.City != null)
                _this.City = modelParams.City;

            if (modelParams.State != null)
                _this.State = modelParams.State;

            if (modelParams.Country != null)
                _this.Country = modelParams.Country;

            if (modelParams.ZipCode != null)
                _this.ZipCode = modelParams.ZipCode;
  
            if (modelParams.Note != null)
                _this.Note = modelParams.Note;
 
            return _this;
        }
    }
}
