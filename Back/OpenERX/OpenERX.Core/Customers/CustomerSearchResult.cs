 
namespace OpenERX.Core.Customers
{
    public class CustomerSearchResult
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

    }
}
