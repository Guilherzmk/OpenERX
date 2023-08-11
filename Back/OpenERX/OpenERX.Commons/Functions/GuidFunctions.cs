namespace OpenERX.Commons.Functions
{
    public static class GuidFunctions
    {
        public static Guid GetGuid(string str, bool newGuidOnError = false)
        {
            var result = newGuidOnError ? Guid.NewGuid() : Guid.Empty;

            if (string.IsNullOrWhiteSpace(str))
                return result;

            if (Guid.TryParse(str, out result))
            {
                if (result == Guid.Empty && newGuidOnError)
                    return Guid.NewGuid();

                return result;
            }

            if (result == Guid.Empty && newGuidOnError)
                return Guid.NewGuid();

            return result;
        }

        public static Guid GetGuid(object str)
        {
            return GetGuid(str?.ToString());
        }

        public static Guid? GetGuidNull(string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return null;

            if (!Guid.TryParse(str, out var result))
                return null;

            return result;

        }

        public static Guid? GetGuidNull(object str)
        {
            return GetGuidNull(str?.ToString());

        }

        public static IList<Guid> GetList(IList<string> list)
        {
            var result = new List<Guid>();

            if (list == null)
                return result;

            result.AddRange(list.Select(item => GetGuid(item)).Where(guid => guid != Guid.Empty));

            return result;
        }

        public static bool IsValid(Guid? value)
        {
            if (value == null)
                return false;

            if (value == Guid.Empty)
                return false;

            return true;
        }

        public static bool IsValid(string str)
        {
            var value = GetGuidNull(str);

            return IsValid(value);
        }

    }
}
