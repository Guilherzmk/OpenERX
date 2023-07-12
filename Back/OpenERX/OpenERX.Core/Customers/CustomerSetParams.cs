
using OpenERX.Commons.Credentials;
using OpenERX.Commons.Functions;
using OpenERX.Commons.Results;
using OpenERX.Commons.Types.Addresses;
using OpenERX.Commons.Types.Emails;
using OpenERX.Commons.Types.Fields;
using OpenERX.Commons.Types.Generics;
using OpenERX.Commons.Types.Phones;
using OpenERX.Commons.Types.Sites;
using OpenERX.Core.Shared.Commons.Types;

namespace OpenERX.Core.Customers
{
    public static class CustomerSetParams
    {
        public static async Task<Customer> SetParamsAsync(
        this Customer _this,
        CustomerParams setParams,
        Credential credential,
        IResultService resultService)
        {

            if (setParams.TypeCode != null)
            {
                _this.TypeCode = (int)setParams.TypeCode;
                _this.TypeName = CustomerType.Get(_this.TypeCode);
            }

            if (setParams.Name != null)
                _this.Name = setParams.Name;

            if (setParams.Nickname != null)
                _this.Nickname = setParams.Nickname;

            if (setParams.Display != null)
                _this.Display = setParams.Display;

            if (setParams.BirthDate != null) //yyyy-MM-dd HH:mm:ss
                _this.BirthDate = DateFunctions.GetDateTimeNullable(setParams.BirthDate);

            if (setParams.PersonTypeCode != null)
            {
                _this.PersonTypeCode = (int)setParams.PersonTypeCode;
                _this.PersonTypeName = PersonType.Get(_this.PersonTypeCode);
            }
    
            if (setParams.Identity != null)
                _this.Identity = setParams.Identity;

            if (setParams.ExternalCode != null)
                _this.ExternalCode = setParams.ExternalCode;

            if (setParams.Addresses != null)
                _this.Addresses = Address.CreateList(setParams.Addresses);

            if (setParams.Phones != null)
                _this.Phones = Phone.CreateList(setParams.Phones);

            if (setParams.Emails != null)
                _this.Emails = Email.CreateList(setParams.Emails);

            if (setParams.Sites != null)
                _this.Sites = Site.CreateList(setParams.Sites);

            if (setParams.Fields != null)
                _this.Fields = DataField.CreateList(setParams.Fields);

            if (setParams.StatusCode != null)
                _this.StatusCode = (int)setParams.StatusCode;

            //if (setParams.StatusName != null)
            //    _this.StatusName = setParams.StatusName;

            if (setParams.StatusDate != null)
                _this.StatusDate = DateFunctions.GetDateTimeNullable(setParams.StatusDate);

            //if (setParams.StatusColor != null)
            //    _this.StatusColor = setParams.StatusColor;

            if (setParams.StatusNote != null)
                _this.StatusNote = setParams.StatusNote;

            if (setParams.OriginId != null)
                _this.OriginId = GuidFunctions.GetGuid(setParams.OriginId);

            //if (setParams.OriginCode != null)
            //    _this.OriginCode = (int)setParams.OriginCode;

            //if (setParams.OriginName != null)
            //    _this.OriginName = setParams.OriginName;

            if (setParams.Note != null)
                _this.Note = setParams.Note;

            if (setParams.StoreId != null)
                _this.StoreId = GuidFunctions.GetGuid(setParams.StoreId);

            //if (setParams.StoreCode != null)
            //    _this.StoreCode = (int)setParams.StoreCode;

            //if (setParams.StoreName != null)
            //    _this.StoreName = setParams.StoreName;

            if (setParams.BrokerId != null)
                _this.BrokerId = GuidFunctions.GetGuid(setParams.BrokerId);

            //if (setParams.BrokerCode != null)
            //    _this.BrokerCode = (int)setParams.BrokerCode;

            //if (setParams.BrokerName != null)
            //    _this.BrokerName = setParams.BrokerName;

            return _this;
        }
    }
}
