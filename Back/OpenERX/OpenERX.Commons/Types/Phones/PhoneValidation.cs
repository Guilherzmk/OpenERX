 
using OpenERX.Commons.Results;

namespace OpenERX.Commons.Types.Phones
{
    public static class PhoneValidation
    {
        public static bool Validate(this Phone address, IResultService resultService)
        {
            var results = new List<ResultMessage>();
 

            resultService.AddMessages(results);

            return results.Count == 0;
        }

    }
}
