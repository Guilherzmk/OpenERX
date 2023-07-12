 
using OpenERX.Commons.Functions;

namespace OpenERX.Commons.Types.Fields
{
    public static class DataField3SetParams
    {
        public static DataField SetParams(
            this DataField _this,
            DataFieldParams setParams)
        {
            var id = GuidFunctions.GetGuid(setParams.Id);
            if (id != Guid.Empty)
                _this.Id = id;

            if (setParams.Key != null)
                _this.Key = setParams.Key;

            if (setParams.Label != null)
                _this.Label = setParams.Label;

            if (setParams.Type != null)
                _this.Type = setParams.Type;

            if (setParams.Value != null)
                _this.Value = setParams.Value;

           

            _this.SetDisplay();

            return _this;
        }
    }
}