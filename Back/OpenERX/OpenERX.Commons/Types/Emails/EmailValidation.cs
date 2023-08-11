 
using OpenERX.Commons.Results;

namespace OpenERX.Commons.Types.Emails
{
    public static class EmailValidation
    {
        public static bool Validate(this Email address, IResultService resultService)
        {
            var results = new List<ResultMessage>();

         

            resultService.AddMessages(results);

            return results.Count == 0;
        }

    }
}
