 
using OpenERX.Commons.Types.Addresses;
using OpenERX.Commons.Types.Emails;
using OpenERX.Commons.Types.Fields;
using OpenERX.Commons.Types.Phones;
using OpenERX.Commons.Types.Sites;

namespace OpenERX.Core.Customers
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Display { get; set; }
        public DateTime? BirthDate { get; set; }
        public int PersonTypeCode { get; set; }
        public string PersonTypeName { get; set; }
        public string Identity { get; set; }
        public string ExternalCode { get; set; }
        public IList<Address> Addresses { get; set; }
        public IList<Phone> Phones { get; set; }
        public IList<Email> Emails { get; set; }
        public IList<Site> Sites { get; set; }
        public IList<DataField> Fields { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime? StatusDate { get; set; }
        public string StatusColor { get; set; }
        public string StatusNote { get; set; }
        public Guid OriginId { get; set; }
        public int OriginCode { get; set; }
        public string OriginName { get; set; }
        public string Note { get; set; }
        public Guid AccountId { get; set; }
        public int AccountCode { get; set; }
        public string AccountName { get; set; }
        public Guid StoreId { get; set; }
        public int StoreCode { get; set; }
        public string StoreName { get; set; }
        public Guid BrokerId { get; set; }
        public int BrokerCode { get; set; }
        public string BrokerName { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreationUserId { get; set; }
        public string CreationUserName { get; set; }
        public DateTime? ChangeDate { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ChangeUserName { get; set; }
        public DateTime? ExclusionDate { get; set; }
        public Guid ExclusionUserId { get; set; }
        public string ExclusionUserName { get; set; }
        public int RecordStatusCode { get; set; }
        public string RecordStatusName { get; set; }
        public Guid VersionId { get; set; }
        public Guid PreviousId { get; set; }
        public DateTime VersionDate { get; set; }

        public Customer()
        {
            this.Id = Guid.NewGuid();
            this.Addresses = new List<Address>();
            this.Phones = new List<Phone>();
            this.Emails = new List<Email>();
            this.Sites = new List<Site>();
            this.Fields = new List<DataField>();
        }

        public override string ToString()
        {
            return this.Name;
        }


    }
}
