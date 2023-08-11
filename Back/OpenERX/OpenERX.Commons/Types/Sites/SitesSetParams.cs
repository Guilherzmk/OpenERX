 
namespace OpenERX.Commons.Types.Sites
{
    public static class SiteSetParams
    {
        public static Site SetParams(
        this Site _this,
        SiteParams modelParams)
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
