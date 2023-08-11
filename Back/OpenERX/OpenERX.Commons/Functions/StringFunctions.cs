using System.Text;
using System.Text.RegularExpressions;
using OpenERX.Commons.Types.Generics;

namespace OpenERX.Commons.Functions
{
    public static class StringFunctions
    {
        public static string GetOnlyNumbers(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            //var reg = new Regex(@"[^0-9]");
            //var ret = reg.Replace(str, string.Empty);
            //return ret;

            var sb = new StringBuilder(str);
            var j = 0;
            var i = 0;
            while (i < sb.Length)
            {
                var isDigit = char.IsDigit(sb[i]);
                if (isDigit)
                {
                    sb[j++] = sb[i++];
                }
                else
                {
                    ++i;
                }
            }
            sb.Length = j;
            var cleaned = sb.ToString();
            return cleaned;
        }

        public static string GetFirstWord(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;


            var array = str.Split(' ');
            return array.Length > 0 ? array[0] : str;
        }

        public static string GetFirstCharacter(string str)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : str.Substring(0, 1);
        }

        public static string GetLastWord(string str)
        {
            var lastWord = str?.Trim().Split(' ').LastOrDefault()?.Trim();

            return lastWord ?? string.Empty;
        }

        public static string GetLastName(string str)
        {
            var list = str?.Trim().Split(' ');
            if (list == null || list.Count() <= 1)
                return null;

            var lastWord = list.LastOrDefault()?.Trim();

            return lastWord ?? string.Empty;
        }

        //public static string RemovePrepositions(string str)
        //{
        //    if (string.IsNullOrWhiteSpace(str))
        //        return string.Empty;



        //    var sb = new StringBuilder();


        //    var list = str.Split(' ');
        //    foreach (var item in list)
        //    {
        //        if (string.IsNullOrWhiteSpace(item))
        //        {
        //            continue;
        //        }

        //        var i = item.ToUpper().Trim();

        //        if (i == "DO" ||
        //            i == "DOS" ||
        //            i == "DA" ||
        //            i == "DAS" ||
        //            i == "DE" ||
        //            i == "DI" ||
        //            i == "E"
        //        )
        //        {
        //            continue;
        //        }

        //        sb.Append(item + " ");
        //    }

        //    return sb.ToString().Trim();
        //}

        public static string RemovePrepositions(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder(str.ToUpper());

            sb
                .Replace(" DO ", " ")
                .Replace(" DOS ", " ")
                .Replace(" DA ", " ")
                .Replace(" DAS ", " ")
                .Replace(" DI ", " ")
                .Replace(" E ", " ");

            return sb.ToString().Trim();
        }

        public static string RemoveLineBreaks(string str)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : Regex.Replace(str, @"\t|\n|\r", "");
        }

        public static string GetValueOrEmpty(string str)
        {
            return string.IsNullOrWhiteSpace(str) ? string.Empty : str;
        }

        //public static string RemoveAccents(string text)
        //{
        //    if (string.IsNullOrWhiteSpace(text))
        //        return string.Empty;

        //    var sbReturn = new StringBuilder();
        //    var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
        //    foreach (var letter in arrayText)
        //    {
        //        if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
        //            sbReturn.Append(letter);
        //    }
        //    return sbReturn.ToString();
        //}

        public static string RemoveAccents(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return null;

            const string from = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç";
            const string to = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCc";

            for (var i = 0; i < from.Length; i++)
            {
                text = text.Replace(from[i].ToString(), to[i].ToString());
            }
            return text;
        }

        public static string RemoveSpecialCharacters(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= '0' && c <= '9' || c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        //public static string GetOnlyNumbers(string str)
        //{
        //    if (string.IsNullOrWhiteSpace(str))
        //        return string.Empty;

        //    var sb = new StringBuilder();
        //    foreach (var c in str)
        //    {
        //        if (c >= '0' && c <= '9')
        //        {
        //            sb.Append(c);
        //        }
        //    }
        //    return sb.ToString();
        //}

        public static string GetOnlyLetters(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GetOnlyLettersAndSpaces(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GetOnlyLettersAndNumbers(string str)
        {

            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= '0' && c <= '9' || c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z')
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        public static string GetOnlyLettersNumbersAndSpaces(string str, bool removeDuplicateSpace = true)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= '0' && c <= '9' || c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c == ' ')
                {
                    sb.Append(c);
                }
            }

            return removeDuplicateSpace ? RemoveDuplicateSpace(sb.ToString()) : sb.ToString();
        }

        public static string RemoveDuplicateSpace(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            return Regex.Replace(str, @"\s+", " ");

            //var stringBuilder = new StringBuilder(str.Length);
            //for (var i = 0; i < str.Length; i++)
            //{
            //    var c = str[i];
            //    if (i == 0 || c != ' ' || (c == ' ' && str[i - 1] != ' '))
            //        stringBuilder.Append(c);
            //}

            //return stringBuilder.ToString().Trim();
        }

        public static string RemoveSubString(string strToRemove, string str)
        {
            if (string.IsNullOrWhiteSpace(strToRemove) || string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var newStr = str.Replace(strToRemove, "");

            return newStr.Trim();
        }

        public static string RemoveWhiteSpace(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            return new string(str.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        public static bool IsNumeric(string str)
        {
            return double.TryParse(str, out _);
        }

        public static string RemoveLastWord(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return string.Empty;

            var idx = str.LastIndexOf(" ", StringComparison.Ordinal);
            if (idx > -1)
                str = str.Remove(idx);

            return str;
        }

        public static string RemoveLastChar(string str)
        {
            return str.Remove(str.Length - 1, 1);
        }

        public static bool AssertLastChar(string str, char c)
        {
            var last = str[str.Length - 1];
            return c == last;
        }


        //public static string CreateFileNameFromDate(string dateFormat = "yyyyMMddHHmmss")
        //{
        //    return DateTime.Now.ToString(dateFormat);
        //}

        public static string GetFileExtension(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;

            var result = "";

            fileName = RemoveDuplicateSpace(fileName).Trim();

            var l = fileName.Split('.');
            if (l.Length <= 1)
                return result;

            foreach (var item in l)
            {
                result = item.Trim();
            }

            return result;
        }

        public static KeyValue GetKeyValue(string str, string separator = null)
        {
            try
            {
                var result = new KeyValue();

                if (string.IsNullOrWhiteSpace(str))
                    return null;

                var array = str.Split(separator);

                if (array.Length <= 0)
                    return null;

                result.Key = array[0]?.Trim();

                if (array.Length > 1)
                {
                    result.Value = array[1]?.Trim();
                }

                return result;
            }
            catch
            {
                return null;
            }
        }

        public static string Concat(params string[] list)
        {
            if (list == null)
                return null;

            var sb = new StringBuilder();

            foreach (var item in list)
            {

                if (string.IsNullOrWhiteSpace(item))
                    continue;

                sb.Append(item);

            }

            return sb.ToString();
        }


        public static IList<long> SplitToLongList(string str, string separator, long minValue = 0)
        {
            var l = new List<long>();

            if (string.IsNullOrWhiteSpace(str))
                return l;

            var ls = str.Split(separator: separator);
            foreach (var i in ls)
            {
                var value = NumberFunctions.GetLong(i);

                if (value >= minValue)
                {
                    l.Add(value);
                }
            }

            return l;
        }

 
        public static IList<string> Split(string str, string separator, bool removeNullOrWhiteSpace = false)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(str))
                return result;

            var l = str.Split(separator);
            foreach (var x in l)
            {
                if (removeNullOrWhiteSpace && string.IsNullOrWhiteSpace(x))
                    continue;

                result.Add(x.Trim());
            }

            return result;
        }


        public static string Right(string str, int length)
        {
            if (string.IsNullOrWhiteSpace(str))
                return str;

            if (str.Length <= length)
                return str;

            return str.Substring(str.Length - length, length);
        }

        public static string CapitalizeFirstLetter(string str)
        {
            str = str.ToLower();

            return str.Length switch
            {
                0 => null,
                1 => char.ToUpper(str[0]).ToString(),
                _ => char.ToUpper(str[0]) + str.Substring(1)
            };
        }

        public static string GetKeyFromNameOrDescription(string nameDesc)
        {
            var str = nameDesc.Trim().ToLower();

            var result = RemoveAccents(str);
            result = GetOnlyLettersAndSpaces(result);
            result = RemoveDuplicateSpace(result);
            result = result.Replace(" ", "model");

            return result;
        }
    }
}
