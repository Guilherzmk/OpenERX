using Microsoft.VisualBasic;
using System.Globalization;
using System.Text;

namespace OpenERX.Commons.Functions
{
    public class DateFunctions
    {
       
        private static string GetDateFormat(string format)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                return "ddMMyyyy";
            }

            var stringFormat = format.Replace("-", "").Replace("/", "").Replace(".", "").Replace(" ", "").Replace("a", "y");


            return stringFormat;
        }


        public static DateTime? GetDateTimeNullable(string date)
        {
            return GetDateTimeNullable(date, DateFormats.ISO);
        }

        public static DateTime? GetDateTimeNullable(string date, DateFormats format)
        {
            if (string.IsNullOrWhiteSpace(date))
                return null;

            DateTime? result = null;

            if (format == DateFormats.ISO)
            {
                if (DateTime.TryParse(date, out var isoDate))
                {
                    result = isoDate;
                }

                return result;
            }
 
            date = StringFunctions.GetOnlyNumbers(date);

            var stringFormat = GetDateFormat(format.ToString());

            date = date.Substring(0, stringFormat.Length);

            if (DateTime.TryParseExact(date, stringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var outDate))
            {
                result = outDate;
            }

            return result;
        }


        public static DateTime? GetDateTimeNullable(string date, string format)
        {
            DateTime? result = null;

            var onlyNumber = StringFunctions.GetOnlyNumbers(date);

            if (string.IsNullOrWhiteSpace(date))
                return null;

            format = format?.Replace("/", "").Replace("-", "").ToLower();

            try
            {
                int day;
                int month;
                int year;

                if (format == "ddmmyyyy" && onlyNumber.Length >= 8)
                {

                    day = Convert.ToInt32(onlyNumber.Substring(0, 2));
                    month = Convert.ToInt32(onlyNumber.Substring(2, 2));
                    year = Convert.ToInt32(onlyNumber.Substring(4, 4));
                    result = new DateTime(year, month, day);

                }
                else if (format == "ddmmyyyyhhmmss" && onlyNumber.Length >= 14)
                {

                    day = Convert.ToInt32(onlyNumber.Substring(0, 2));
                    month = Convert.ToInt32(onlyNumber.Substring(2, 2));
                    year = Convert.ToInt32(onlyNumber.Substring(4, 4));

                    var hour = Convert.ToInt32(onlyNumber.Substring(8, 2));
                    var minute = Convert.ToInt32(onlyNumber.Substring(10, 2));
                    var second = Convert.ToInt32(onlyNumber.Substring(12, 2));

                    result = new DateTime(year, month, day, hour, minute, second);
                }
                else
                {
                    if (DateTime.TryParse(date, out var outDate))
                    {
                        result = outDate;
                    }
                }

                if (format == "ddmmyyyy" ||
                    format == "yyyymmdd" ||
                    format == "mmddyyyy")
                {
                    result = ((DateTime)result).AddHours(12);
                }
            }
            catch
            {
                return result;
            }



            return result;
        }

        public static DateTime? GetDate(string date)
        {
            DateTime? result = null;

            if (DateTime.TryParse(date, out var outDate))
            {
                result = outDate;
            }

            return result;
        }

        public static DateTime? GetDateFromUnixTimeMilliseconds(long unixTimeInMilliseconds)
        {
            if (unixTimeInMilliseconds == 0)
                return null;

            try
            {
                return DateTimeOffset.FromUnixTimeMilliseconds(unixTimeInMilliseconds).ToUniversalTime().DateTime;
            }
            catch
            {
                return null;
            }
        }

 

        public static DateTime? GetDateTime(object obj)
        {
            return GetDateTime(obj.ToString());
        }

        public static DateTime? GetDateTime(string str)
        {
            DateTime? aux = null;
            if (DateTime.TryParse(str, out var i))
                aux = i;

            return aux;
        }
 
        public static DateTime GetDateTimeNotNull(object obj)
        {
            return GetDateTimeNotNull(obj.ToString());
        }

        public static DateTime GetDateTimeNotNull(string str)
        {
            if (!DateTime.TryParse(str, out var i ))
                return DateTime.Now;

            return i;
        }

        public static DateTime? GetLastDayOfMonth(DateTime? date)
        {
            if (date == null)
                return null;

            var x = ((DateTime)date).AddMonths(1);

            x = new DateTime(x.Year, x.Month, 1).AddDays(-1);

            return x;

        }

        public static DateTime GetLastDayOfMonth(DateTime date)
        {
            var x = date.AddMonths(1);

            x = new DateTime(x.Year, x.Month, 1).AddDays(-1);

            return x;

        }

        public static DateTime? TryParse(string str)
        {
            ////DateTime? aux = null;
            ////if (DateTime.TryParse(str, out var i))
            ////    aux = i;

            try
            {
                var aux = Convert.ToDateTime(str);

                return aux;
            }
            catch
            {
                return null;
            }

        }

        public static bool IsToday(DateTime? date)
        {
            if (!DateTime.TryParse(date.ToString(), out var dt)) return false;

            return dt.Date == DateTime.Today.Date;
        }

        public static bool IsToday(DateTime date)
        {
            return date.Date == DateTime.Today.Date;
        }

        public static bool IsToday(string date)
        {
            if (!DateTime.TryParse(date, out var dt)) return false;

            return dt.Date == DateTime.Today.Date;
        }

        public static string Format(DateTime date, string format)
        {
            if (string.IsNullOrWhiteSpace(format))
                return date.ToString("dd/MM/yyyy");

            format = format.Replace("a", "y");

            try
            {
                return date.ToString(format);
            }
            catch
            {
                return date.ToString("dd/MM/yyyy");
            }

        }

        public static string Format(DateTime? date, string format)
        {
            if (date == null)
                return null;

            format = format.Replace("a", "y");
            return Format((DateTime)date, format);
        }

        public static TimeSpan? GetTimeSpan(string str)
        {
            TimeSpan? aux = null;
            if (TimeSpan.TryParse(str, out var i))
                aux = i;

            return aux;
        }

        public static DateTime? GetDateTimeWithoutYear(string date, string hour = null)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(date))
                    return null;

                var dateFormat = string.IsNullOrWhiteSpace(hour) ? "dd/MM/yyyy" : "dd/MM/yyyy HH:mm:ss";
                var fullHour = hour?.Length == 5 ? hour + ":00" : hour;
                var dateHour = dateFormat == "dd/MM/yyyy" ? null : " " + fullHour;

                var dateTime = DateTime.ParseExact(date + "/" + DateTime.Now.Year + dateHour, dateFormat,
                    CultureInfo.InvariantCulture);

                if (dateTime < DateTime.Now)
                    return DateTime.ParseExact(date + "/" + DateTime.Now.Year + dateHour, dateFormat,
                        CultureInfo.InvariantCulture);

                return DateTime.ParseExact(date + "/" + DateTime.Now.AddYears(-1).Year + dateHour, dateFormat,
                    CultureInfo.InvariantCulture);
            }
            catch
            {
                return null;
            }
        }

        public static DateTime Resolve(string str)
        {
            var result = ResolveNullable(str);

            if (result == null)
                return new DateTime(1900, 1, 1);

            return (DateTime)result;
        }

        public static DateTime? ResolveNullable(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            var aux = str.Replace("-", ";").Replace("/", ";").Replace(".", ";").Replace("  ", ";").Replace(" ", ";").Replace(":", ";");

            var l = aux.Split(';');

            if (l.Length == 0)
                return null;

            l = l.Where(i => !string.IsNullOrWhiteSpace(i)).ToArray();

            var x = 0;
            var type = "ISO";


            //ddMMyyyy,
            //yyyyMMdd,
            //MMddyyyy,
            //ddMMyyyyHHmmss,
            //yyyyMMddHHmmss,
            //MMddyyyyHHmmss,
            //ISO

            var v0 = "0";
            var v1 = "0";
            var v2 = "0";
            var v3 = "0";
            var v4 = "0";
            var v5 = "0";
            var v6 = "0";


            foreach (var i in l)
            {
                if (x == 0)
                    v0 = i;
                else if (x == 1)
                    v1 = i;
                else if (x == 2)
                    v2 = i;
                else if (x == 3)
                    v3 = i;
                else if (x == 4)
                    v4 = i;
                else if (x == 5)
                    v5 = i;
                else if (x == 6)
                    v6 = i;
                x++;
            }

            if (v0.Length == 4)
                type = "ISO";
            else if (v0.Length == 2 && (NumberFunctions.GetInt(v1) > 12 || v1.Length > 2))
                type = "MMddyyyy";
            else if (v0.Length == 2)
                type = "ddMMyyyy";



            DateTime? result = null;

            if (type is "ISO" or "MMddyyyy")
            {
                var culture = CultureInfo.CreateSpecificCulture("en-US");
                var styles = DateTimeStyles.None;

                if (DateTime.TryParse(str, culture, styles, out var outDate))
                    result = outDate;
            }
            else
            {
                var day = Convert.ToInt32(v0);
                var month = Convert.ToInt32(v1);
                var year = Convert.ToInt32(v2);
                var hour = Convert.ToInt32(v3);
                var minute = Convert.ToInt32(v4);
                var second = Convert.ToInt32(v5);

                try
                {
                    result = new DateTime(year, month, day, hour, minute, second);
                }
                catch
                {
                    result = null;
                }
            }

            if (result != null && aux.Replace(";", "").Length <= 10)
                result = ((DateTime)result).AddHours(12);

            return result;
        }

        public static string GetHumanDate(DateTime? firstDate, DateTime? lastDate, bool showSeconds = false)
        {
            var date1 = Convert.ToDateTime(firstDate);
            var date2 = Convert.ToDateTime(lastDate);

            var timeSpanDate = date2 - date1;

            return GetHumanDate(timeSpanDate, showSeconds);
        }

        public static string GetHumanDate(TimeSpan timeSpanDate, bool showSeconds = false)
        {
            if (timeSpanDate == TimeSpan.Zero)
                return null;

            var sb = new StringBuilder();

            var days = timeSpanDate.Days;
            var hours = timeSpanDate.Hours;
            var minutes = timeSpanDate.Minutes;
            var seconds = timeSpanDate.Seconds;

            //Day
            if (days > 1)
                sb.Append(string.Concat(days, " dias"));
            else if (days == 1)
                sb.Append(string.Concat(days, " dia"));

            if (!string.IsNullOrWhiteSpace(sb.ToString()))
                sb.Append(string.Concat(", "));

            //Hour
            if (hours > 1)
                sb.Append(string.Concat(hours, " horas"));
            else if (hours is 1)
                sb.Append(string.Concat(hours, " hora"));

            if (showSeconds)
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                    sb.Append(string.Concat(", "));
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(sb.ToString()))
                    sb.Append(string.Concat(" e "));
            }

            //Minute
            if (minutes > 1)
                sb.Append(string.Concat(minutes, " minutos"));
            else if (minutes is 1)
                sb.Append(string.Concat(minutes, " minuto"));

            if (showSeconds && !string.IsNullOrWhiteSpace(sb.ToString()))
                sb.Append(string.Concat(" e "));

            //Second
            if (showSeconds)
            {
                if (seconds is > 1 or 0)
                    sb.Append(string.Concat(seconds, " segundos"));
                else if (seconds == 1)
                    sb.Append(string.Concat(seconds, " segundo"));
            }

            var result = StringFunctions.RemoveDuplicateSpace(sb.ToString().Replace(", ,", ","));

            if (showSeconds)
            {
                result = result.Replace(", e", " e");
                result = result.Replace(" e 0 segundos", "");
            }

            if (result.EndsWith(", "))
                result = result.Replace(", ", "");

            return StringFunctions.RemoveDuplicateSpace(result);
        }
    }
}
