 
namespace OpenERX.Commons.Credentials
{
    public class Credential
    {
        public Guid AccountId { get; set; }
        public int AccountCode { get; set; }
        public string AccountName { get; set; }
        public Guid UserId { get; set; }
        public int UserCode { get; set; }
        public string UserName { get; set; }
        public int ProfileCode { get; set; }
        public int AccessTypeCode { get; set; }
        public Guid StoreId { get; set; }
        public int StoreCode { get; set; }
        public string StoreName { get; set; }
        public Guid BrokerId { get; set; }
        public int BrokerCode { get; set; }
        public string BrokerName { get; set; }
        public string AccessKey { get; set; }
        public Guid SessionId { get; set; }
        public int TypeCode { get; set; }
        public int StatusCode { get; set; }
        public string Phone { get; set; }
        public bool Authorized { get; set; }
        public bool SignOut { get; set; }
        public string ApiKey { get; set; }
        public string Avatar { get; set; }
     
        public string TimeZoneId { get; set; }

        public Credential()
        {
            this.TimeZoneId = "E. South America Standard Time";
        }

        public static Credential GetAnonymous()
        {
            return new Credential
            {

            };
        }
    }
}
