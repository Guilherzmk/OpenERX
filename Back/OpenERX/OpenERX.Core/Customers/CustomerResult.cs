 
using OpenERX.Commons.Types.Addresses;
using OpenERX.Commons.Types.Emails;
using OpenERX.Commons.Types.Fields;
using OpenERX.Commons.Types.Phones;
using OpenERX.Commons.Types.Sites;

namespace OpenERX.Core.Customers
{
    public class CustomerResult
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Display { get; set; }
        public string BirthDate { get; set; }
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
        public string StatusDate { get; set; }
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
        public string CreationDate { get; set; }
        public Guid CreationUserId { get; set; }
        public string CreationUserName { get; set; }
        public string ChangeDate { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ChangeUserName { get; set; }

        public CustomerResult(Customer model )
        {
            this.Id = model.Id;
            this.Code = model.Code;
            this.TypeCode = model.TypeCode;
            this.TypeName = model.TypeName;
            this.Name = model.Name;
            this.Nickname = model.Nickname;
            this.Display = model.Display;
            this.BirthDate = model.BirthDate.ToString() ;
            this.PersonTypeCode = model.PersonTypeCode;
            this.PersonTypeName = model.PersonTypeName;
            this.Identity = model.Identity;
            this.ExternalCode = model.ExternalCode;
            this.Addresses = model.Addresses;
            this.Phones = model.Phones;
            this.Emails = model.Emails;
            this.Sites = model.Sites;
            this.Fields = model.Fields;
            this.StatusCode = model.StatusCode;
            this.StatusName = model.StatusName;
            this.StatusDate = model.StatusDate.ToString();
            this.StatusColor = model.StatusColor;
            this.StatusNote = model.StatusNote;
            this.OriginId = model.OriginId;
            this.OriginCode = model.OriginCode;
            this.OriginName = model.OriginName;
            this.Note = model.Note;
            this.AccountId = model.AccountId;
            this.AccountCode = model.AccountCode;
            this.AccountName = model.AccountName;
            this.StoreId = model.StoreId;
            this.StoreCode = model.StoreCode;
            this.StoreName = model.StoreName;
            this.BrokerId = model.BrokerId;
            this.BrokerCode = model.BrokerCode;
            this.BrokerName = model.BrokerName;
            this.CreationDate = model.CreationDate.ToString();
            this.CreationUserId = model.CreationUserId;
            this.CreationUserName = model.CreationUserName;
            this.ChangeDate = model.ChangeDate?.ToString();
            this.ChangeUserId = model.ChangeUserId;
            this.ChangeUserName = model.ChangeUserName;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
