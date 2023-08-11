 
using OpenERX.Commons.Results;

namespace OpenERX.Commons.Types.Sites
{
    public static class SiteValidation
    {
        public static bool Validate(this Site address, IResultService resultService)
        {
            var results = new List<ResultMessage>();
 

            resultService.AddMessages(results);

            return results.Count == 0;
        }

    }
}
