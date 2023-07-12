using OpenERX.Commons.Types.Generics;

namespace OpenERX.Commons.Params
{
    public class UpdateStatusParams3
    {
        public int? Code { get; set; }
        public string Date { get; set; }
        public string Note { get; set; }
        public bool? Notification { get; set; }
        public int? ReasonCode { get; set; }
        public IList<KeyValue> Args { get; set; }
    }
}
