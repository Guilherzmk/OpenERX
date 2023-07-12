 

using System.Text;
using OpenERX.Commons.Functions;

namespace OpenERX.Commons.Types.Fields
{
    public partial class DataField
    {
        public Guid Id { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Display { get; set; }

        public DataField()
        {
            this.Id = Guid.NewGuid();
        }
 
        public DataField(string key, object value)
        {
            this.Id = Guid.NewGuid();

            if (string.IsNullOrWhiteSpace(key)) return;

            this.Key = key;
            this.Value = value?.ToString();

            this.SetDisplay();
        }
 
        public string Hash
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(this.Key);
                sb.Append(this.Value);

                var x = StringFunctions.RemoveSpecialCharacters(sb.ToString());
                x = StringFunctions.RemoveWhiteSpace(x);
                x = x?.ToLower();

                return x;
            }
        }
 
        public static implicit operator string(DataField field)
        {
            return field?.Value;
        }

        public static implicit operator short(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return 0;

            return short.TryParse((string)field.Value, out var result) ? result : (short)0;
        }

        public static implicit operator short?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return short.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator int(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return 0;

            return int.TryParse((string)field.Value, out var result) ? result : 0;
        }

        public static implicit operator int?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return int.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator long(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return 0;

            return long.TryParse((string)field.Value, out var result) ? result : 0;
        }

        public static implicit operator long?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return long.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator float(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return 0;

            return float.TryParse((string)field.Value, out var result) ? result : 0;
        }

        public static implicit operator float?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return float.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator double(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return 0;

            return double.TryParse((string)field.Value, out var result) ? result : 0;
        }

        public static implicit operator double?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return double.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator DateTime(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return new DateTime(1900, 1, 1);

            return DateTime.TryParse((string)field.Value, out var result) ? result : new DateTime(1900, 1, 1);
        }

        public static implicit operator DateTime?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return new DateTime(1900, 1, 1);

            return DateTime.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator bool(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return false;

            return bool.TryParse((string)field.Value, out var result) && result;
        }

        public static implicit operator bool?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return bool.TryParse((string)field.Value, out var result) ? result : null;
        }

        public static implicit operator Guid(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return Guid.Empty;

            return Guid.TryParse((string)field.Value, out var result) ? result : Guid.Empty;
        }

        public static implicit operator Guid?(DataField field)
        {
            if (string.IsNullOrWhiteSpace(field?.Value))
                return null;

            return Guid.TryParse((string)field.Value, out var result) ? result : null;
        }

    }
}
