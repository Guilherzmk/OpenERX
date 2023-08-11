 

namespace OpenERX.Commons.Types.Emails
{
    public partial class Email
    {
        public static Email Create(EmailParams createParams)
        {
            return new Email().SetParams(createParams);
        }

        public static IList<Email> CreateList(IList<EmailParams> createParams)
        {
            var list = new List<Email>();

            if (createParams == null)
                return list;

            list.AddRange(createParams.Select(Create));

            return list;
        }
    }
}
