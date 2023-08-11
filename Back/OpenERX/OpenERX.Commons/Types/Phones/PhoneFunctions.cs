using System.Text;
using OpenERX.Commons.Functions;

namespace OpenERX.Commons.Types.Phones
{
    public static class PhoneFunctions
    {
        public static void Part(string phone, out int ddd, out long number)
        {
            phone = StringFunctions.GetOnlyNumbers(phone);

            number = 0;

            if (phone.Length <= 2)
            {
                ddd = NumberFunctions.GetShort(phone);
            }
            else
            {
                ddd = NumberFunctions.GetShort(phone.Substring(0, 2));
                number = NumberFunctions.GetLong(phone.Substring(2, phone.Length - 2));
            }
        }

        public static void Part(string phone, out int? ddd, out long? number)
        {
            phone = StringFunctions.GetOnlyNumbers(phone);

            number = null;

            if (phone.Length <= 2)
            {
                ddd = NumberFunctions.GetShortNull(phone);
            }
            else
            {
                ddd = NumberFunctions.GetShortNull(phone.Substring(0, 2));
                number = NumberFunctions.GetLongNull(phone.Substring(2, phone.Length - 2));
            }
        }

        public static int GetDdd(string phone)
        {
            try
            {
                if (phone == null)
                    return 0;

                phone = StringFunctions.GetOnlyNumbers(phone);

                return NumberFunctions.GetShort(phone.Length <= 2 ? phone : phone.Substring(0, 2));
            }
            catch (Exception)
            {

                return 0;
            }

        }

        public static long GetNumber(string phone)
        {
            try
            {
                if (phone == null)
                    return 0;

                phone = StringFunctions.GetOnlyNumbers(phone);

                return NumberFunctions.GetLong(phone.Length <= 2 ? phone : phone.Substring(2, phone.Length - 2));
            }
            catch (Exception)
            {

                return 0;
            }


        }

        public static PhoneDddNumber GetPhone(string phone)
        {
            try
            {
                if (phone == null)
                    return new PhoneDddNumber();

                var result = new PhoneDddNumber
                {
                    Ddd = GetDdd(phone),
                    Number = GetNumber(phone)
                };

                return result;
            }
            catch (Exception)
            {
                return new PhoneDddNumber();
            }


        }

        public static string Join(int? ddd, long? number, bool format = false)
        {
            return Join(null, ddd, number, format);
        }

        public static string Join(int? countryCode, int? ddd, long? number, bool format = false)
        {
            var sb = new StringBuilder();

            if (countryCode.HasValue)
                sb.Append(countryCode.ToString());

            if (format)
            {
                if (ddd.HasValue)
                    sb.Append(ddd?.ToString("00"));

                if (number.HasValue)
                {
                    if (number.ToString().Length > 8)
                        sb.Append(number?.ToString("000000000"));
                    else
                        sb.Append(number?.ToString("00000000"));
                }
            }
            else
            {
                if (ddd.HasValue)
                    sb.Append(ddd?.ToString());

                if (number.HasValue)
                    sb.Append(number?.ToString());
            }

            return sb.ToString();
        }

        public static string Format(int? ddd, long? number, string type)
        {
            var sb = new StringBuilder();

            if (ddd.HasValue)
            {
                sb.Append("(" + ddd + ")");
            }

            if (number.HasValue)
            {
                if (number.ToString().Length > 8)
                {
                    sb.Append(" " + ((long)number).ToString("00000-0000"));
                }
                else
                {
                    sb.Append(" " + ((long)number).ToString("0000-0000"));
                }
            }

            if (!String.IsNullOrWhiteSpace(type))
            {
                sb.Append(" (" + type.ToUpper() + ")");
            }


            return sb.ToString();
        }

        public static string Format(int? ddd, long? number)
        {

            var sb = new StringBuilder();

            if (ddd.HasValue)
            {
                sb.Append("(" + ddd + ")");
            }

            if (number.HasValue)
            {
                if (number.ToString().Length > 8)
                {
                    sb.Append(" " + ((long)number).ToString("00000-0000"));
                }
                else
                {
                    sb.Append(" " + ((long)number).ToString("0000-0000"));
                }
            }

            return sb.ToString();
        }

        public static string Format(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return null;

            var x = GetPhone(phone);
            return Format(x.Ddd, x.Number);
        }

        public static string Format(int? countryCode, int? ddd, long? number, string type)
        {
            var sb = new StringBuilder();

            if (countryCode.HasValue)
                sb.Append(countryCode.ToString());

            if (ddd.HasValue)
                sb.Append("(" + ddd?.ToString("00") + ")");

            if (number.HasValue)
            {
                if (number.ToString().Length > 8)
                    sb.Append(" " + ((long)number).ToString("00000-0000"));
                else
                    sb.Append(" " + ((long)number).ToString("0000-0000"));
            }

            if (!string.IsNullOrWhiteSpace(type))
                sb.Append(" (" + type.ToUpper() + ")");

            return sb.ToString();
        }

 
        public static bool IsValid(int? ddd, long? number)
        {
            if (ddd == null || number == null)
                return false;

            if (ddd < 11 || ddd > 99)
                return false;

            if (number < 9999999 || number > 999999999)
                return false;

            return true;
        }

        public static bool IsValid(string ddd, string number)
        {
            return IsValid(NumberFunctions.GetInt(ddd), NumberFunctions.GetLong(number));
        }

        public static bool IsValid(string phone)
        {
            return IsValid(GetPhone(phone));
        }

        public static bool IsValid(PhoneDddNumber phone)
        {
            return IsValid(phone?.Ddd, phone?.Number);
        }

        public static bool IsMobile(Phone phone)
        {
            var x = GetPhone(phone?.Number);
            return x?.Number > 900000000;
        }

        public static bool IsMobile(long? number)
        {
            return number > 900000000;
        }

        public static bool IsMobile(string number)
        {
            return IsMobile(NumberFunctions.GetLongNull(number));
        }
    }
}