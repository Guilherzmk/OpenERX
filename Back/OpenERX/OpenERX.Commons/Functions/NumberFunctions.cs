using System.Globalization;
using System.Text;

namespace OpenERX.Commons.Functions
{
    public static class NumberFunctions
    {
        public static short GetShort(object obj, short isNull = 0)
        {
            return obj != null ? GetShort(obj.ToString()) : isNull;
        }

        public static short GetShort(string str, short isNull = 0)
        {

            if (str == null)
                return isNull;

            short.TryParse(str, out var aux);

            return aux;
        }

        public static short? GetShortNull(object obj)
        {
            if (obj == null)
                return null;

            return GetShortNull(obj.ToString());
        }

        public static short? GetShortNull(string str)
        {
            short? aux = null;

            if (str == null)
                return null;

            if (short.TryParse(str, out var i))
                aux = i;

            return aux;
        }

        public static int GetInt(object obj, int isNull = 0)
        {
            return obj != null ? GetInt(obj.ToString()) : isNull;
        }

        public static int GetInt(string str, int isNull = 0)
        {

            if (str == null)
                return isNull;

            str = StringFunctions.GetOnlyNumbers(str);

            int.TryParse(str, out var aux);

            return aux;
        }

        public static int? GetIntNull(object obj)
        {
            if (obj == null)
                return null;

            return GetIntNull(obj.ToString());
        }

        public static int? GetIntNull(string str)
        {
            int? aux = null;
            if (str == null)
                return null;

            str = StringFunctions.GetOnlyNumbers(str);
            if (int.TryParse(str, out var i))
                aux = i;

            return aux;
        }

        public static long GetLong(object obj, int isNull = 0)
        {
            return obj == null ? isNull : GetLong(obj.ToString(), isNull);
        }

        public static long GetLong(string str, int isNull = 0)
        {
            if (str == null)
                return isNull;

            str = StringFunctions.GetOnlyNumbers(str);
            if (!long.TryParse(str, out var aux))
                aux = isNull;

            return aux;
        }

        public static long? GetLongNull(object obj)
        {
            if (obj == null)
                return null;

            return GetLongNull(obj.ToString());
        }

        public static long? GetLongNull(string str)
        {
            if (str == null)
                return null;

            long? aux = null;
            str = StringFunctions.GetOnlyNumbers(str);
            if (long.TryParse(str, out var i))
                aux = i;

            return aux;
        }

        public static decimal? GetDecimalNull(object obj, string decimalSplit = ",")
        {
            if (obj == null)
                return null;

            return GetDecimalNull(obj.ToString(), decimalSplit);
        }

        public static decimal? GetDecimalNull(string str, string decimalSplit = ",")
        {
            if (str == null)
                return null;

            decimal? aux = null;

            if (decimalSplit == ".")
            {
                str = str.Replace(",", "");
                str = str.Replace(".", ",");
            }
            else if (decimalSplit == ",")
            {
                str = str.Replace(".", "");
            }

            str = str.Replace("R$", "");
            str = str.Replace("%", "");
            str = StringFunctions.RemoveWhiteSpace(str);


            if (decimal.TryParse(str, NumberStyles.Any, new CultureInfo("pt-BR"), out var i))
                aux = i;

            return aux;
        }

        public static decimal GetDecimal(object obj, string decimalSplit = ",")
        {
            if (obj == null)
                return 0;

            return GetDecimal(obj.ToString(), decimalSplit);
        }

        public static decimal GetDecimal(string str, string decimalSplit = ",")
        {
            if (str == null)
                return 0;

            if (decimalSplit == ".")
            {
                str = str.Replace(",", "");
                str = str.Replace(".", ",");
            }
            else if (decimalSplit == ",")
            {
                str = str.Replace(".", "");
            }

            str = str.Replace("R$", "");
            str = str.Replace("%", "");
            str = StringFunctions.RemoveWhiteSpace(str);

            decimal.TryParse(str, NumberStyles.Any, new CultureInfo("pt-BR"), out var aux);


            return aux;
        }

        public static double? GetDoubleNull(object obj, string decimalSplit = ",")
        {
            if (obj == null)
                return null;

            return GetDoubleNull(obj.ToString(), decimalSplit);
        }

        public static double? GetDoubleNull(string str, string decimalSplit = ",")
        {
            if (str == null)
                return null;

            double? aux = null;

    

            if (decimalSplit == ".")
            {
                str = str.Replace(",", "");
                str = str.Replace(".", ",");
            }
            else if (decimalSplit == ",")
            {
                str = str.Replace(".", "");
            }

            str = str.Replace("R$", "");
            str = str.Replace("%", "");
            str = StringFunctions.RemoveWhiteSpace(str);


            if (double.TryParse(str, NumberStyles.Any, new CultureInfo("pt-BR"), out var i))
                aux = i;

            return aux;
        }

        public static double GetDouble(object obj, string decimalSplit = ",")
        {
            if (obj == null)
                return 0;

            return GetDouble(obj.ToString(), decimalSplit);
        }

        public static double GetDouble(string str, string decimalSplit = ",")
        {
            if (str == null)
                return 0;

            if (string.IsNullOrWhiteSpace(str)) return 0;

            if (decimalSplit == ".")
            {
                str = str.Replace(",", "");
                str = str.Replace(".", ",");
            }
            else if (decimalSplit == ",")
            {
                str = str.Replace(".", "");
            }

            str = str.Replace("R$", "");
            str = str.Replace("%", "");
            str = StringFunctions.RemoveWhiteSpace(str);

            double.TryParse(str, NumberStyles.Any, new CultureInfo("pt-BR"), out var aux);

            return aux;
        }
 
        public static double GetUglyDouble(string str, int decimalMaxDigits = 2)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(str)) return 0;

                decimalMaxDigits++;

                var n = 0;
                var l = str.Length - 1;
                var sb = new StringBuilder();
                var found = false;
                for (var i = l; i >= 0; i--)
                {
                    var x = str[i];
                    n++;
                    if (x is ',' or '.' && !found && n <= decimalMaxDigits)
                    {
                        sb.Insert(0, ',');
                        found = true;
                    }
                    else if (char.IsDigit(x) || x == '-')
                    {
                        sb.Insert(0, x);
                    }
                }


                double.TryParse(sb.ToString(), NumberStyles.Any, new CultureInfo("pt-BR"), out var aux);

                return aux;
            }
            catch
            {
                return 0;
            }
        }

        public static string GetPercent(double x, double total)
        {
            try
            {
                if (total == 0)
                    return "0%";

                var result = ( x / total) * 100.0;

                return result.ToString("N") + "%";
            }
            catch
            {
                return "0%";
            }
        }

        public static double GetPercentDouble(double x, double total)
        {
            try
            {
                if (total == 0)
                    return 0;

                var result = (x / total) * 100.0;

                return result;
            }
            catch
            {
                return 0;
            }
        }
    }
}
