 
namespace OpenERX.Commons.Types.Fields
{
    public static class DataFieldExtensions
    {
        public static DataFieldParams ToParams(this DataField _this)
        {
            return new DataFieldParams
            {
                Key = _this.Key,
                Label = _this.Label,
                Type = _this.Type,
                Value = _this.Value
            };
        }

        public static IList<DataFieldParams> ToParams(this IList<DataField> list)
        {
            var l = new List<DataFieldParams>();

            if (list == null)
                return l;

            foreach (var item in list)
            {
                l.Add(item.ToParams());
            }

            return l;
        }

        public static IList<DataField> UpdateList(this IList<DataField> list, DataField dataField)
        {
            if (dataField == null)
                return list;

            for (var i = 0; i < list.Count; i++)
            {
                var item = list[i];

                if (item.Hash == dataField.Hash)
                {
                    list[i] = dataField;
                    return list;
                }
            }

            list.Insert(0, dataField);

            return list;
        }

        public static DataField Add(this IDataField3List _list, DataFieldParams dataFieldParams)
        {
            _list.Fields ??= new List<DataField>();
            var dataField = DataField.Create(dataFieldParams);
            _list.Fields.Add(dataField);
            return dataField;
        }

        public static bool Delete(this IDataField3List _list, Guid id)
        {
            _list.Fields ??= new List<DataField>();

            foreach (var item in _list.Fields)
            {
                if (item.Id != id) continue;

                _list.Fields.Remove(item);
                return true;
            }

            return false;
        }

        public static DataField Update(this IDataField3List _list, Guid id, DataFieldParams dataFieldParams)
        {
            _list.Fields ??= new List<DataField>();

            foreach (var item in _list.Fields)
            {
                if (item.Id == id)
                {
                    return item.Update(dataFieldParams);
                }
            }

            return null;
        }

        public static DataField Update(this DataField _this, DataFieldParams updateParams)
        {
            return _this.SetParams(updateParams);
        }

        public static bool Exists(this IList<DataField> _list, DataField dataField)
        {
            if (dataField == null)
                return false;

            foreach (var item in _list)
            {
                if (item.Hash == dataField.Hash)
                {
                    return true;
                }
            }

            return false;
        }

        public static string SetDisplay(this DataField _this)
        {
            if (_this.Type == DataType.Date)
                _this.Display = ((DateTime?)_this)?.ToString("dd/MM/yyyy") ?? _this.Value;
            else if (_this.Type == DataType.DateTime)
                _this.Display = ((DateTime?)_this)?.ToString("dd/MM/yyyy HH:mm:ss") ?? _this.Value;
            else if (_this.Type == DataType.Integer)
                _this.Display = ((long?)_this)?.ToString("D") ?? _this.Value;
            else if (_this.Type == DataType.Boolean)
                _this.Display = ((bool?)_this) == true ? "Sim" : "Não";
            else if (_this.Type == DataType.Float)
                _this.Display = ((double?)_this)?.ToString("N") ?? _this.Value;
            else if (_this.Type == DataType.Money)
                _this.Display = ((double?)_this)?.ToString("N") ?? _this.Value;
            else if (_this.Type == DataType.Percentage)
                _this.Display = ((double?)_this)?.ToString("P") ?? _this.Value;
            else
                _this.Display = _this.Value;

            return _this.Display;
        }
    }
}
