 
namespace OpenERX.Commons.Types.Phones
{
    public static class PhoneSetParams
    {
        public static Phone SetParams(
            this Phone _this,
            PhoneParams modelParams)
        {

            if (modelParams.TypeCode != null)
                _this.TypeCode = modelParams.TypeCode ?? 0;

            if (modelParams.TypeName != null)
                _this.TypeName = modelParams.TypeName;

            if (modelParams.Number != null)
                _this.Number = modelParams.Number;
 
            if (modelParams.Note != null)
                _this.Note = modelParams.Note;
 
            return _this;
        }
    }
}