using System.Text;
using System.Text.RegularExpressions;

namespace OpenERX.Commons.Types.Emails
{
    public static class EmailFunctions
    {
        public static string Format(string email, string typeName)
        {
            var sb = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(email))
            {
                sb.Append(email.ToUpper());
            }

            if (!string.IsNullOrWhiteSpace(typeName))
            {
                sb.Append(" (" + typeName.ToUpper() + ")");
            }

            return sb.ToString();
        }

        public static bool IsValid(Email email)
        {
            return email != null && IsValid(email.Address);
        }

        public static bool IsValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            var validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                                    + @"([-a-z0-9!#$%&'*+/=?^model`{|}~]|(?<!\.)\.)*)(?<!\.)"
                                    + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(validEmailPattern, RegexOptions.IgnoreCase).IsMatch(email);

        }
    }
}
