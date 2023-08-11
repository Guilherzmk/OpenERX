 

namespace OpenERX.Commons.Types.Emails
{
    public static class EmailSetParams
    {
        public static Email SetParams(
        this Email _this,
        EmailParams modelParams)
        {
            if (modelParams.TypeCode != null)
                _this.TypeCode = modelParams.TypeCode ?? 0;

            if (modelParams.TypeName != null)
                _this.TypeName = modelParams.TypeName;

            if (modelParams.Address != null)
                _this.Address = modelParams.Address;
 
            if (modelParams.Note != null)
                _this.Note = modelParams.Note;

 
            return _this;
        }
    }
}
