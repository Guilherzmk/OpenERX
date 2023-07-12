using OpenERX.Commons.Types.Generics;

namespace OpenERX.Api.Results
{
    public class ResponseMessage
    {
        public string Code { get; set; }
        public string Text { get; set; }
        public IList<KeyValue> Values { get; set; }
    }
}
