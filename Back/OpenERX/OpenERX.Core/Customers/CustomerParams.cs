
using Newtonsoft.Json;
using OpenERX.Commons.Types.Addresses;
using OpenERX.Commons.Types.Emails;
using OpenERX.Commons.Types.Fields;
using OpenERX.Commons.Types.Phones;
using OpenERX.Commons.Types.Sites;

namespace OpenERX.Core.Customers
{
    public class CustomerParams
    {
        public int? TypeCode { get; set; }
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("nickname")]
        public string? Nickname { get; set; }
        public string? Display { get; set; }
        [JsonProperty("birthDate")]
        public string? BirthDate { get; set; }
        public int? PersonTypeCode { get; set; }
        [JsonProperty("identity")]
        public string? Identity { get; set; }
        public string? ExternalCode { get; set; }
        public IList<AddressParams>? Addresses { get; set; }
        public IList<PhoneParams>? Phones { get; set; }
        public IList<EmailParams>? Emails { get; set; }
        public IList<SiteParams>? Sites { get; set; }
        public IList<DataFieldParams>? Fields { get; set; }
        public int? StatusCode { get; set; }
        public string? StatusDate { get; set; }
        public string? StatusNote { get; set; }
        public string? OriginId { get; set; }
        public string? StoreId { get; set; }
        public string? BrokerId { get; set; }
        [JsonProperty("note")]
        public string?  Note { get; set; }
    }
}
