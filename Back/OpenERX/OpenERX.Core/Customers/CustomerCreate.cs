
using OpenERX.Commons.Credentials;
using OpenERX.Commons.Functions;
using OpenERX.Commons.Results;

namespace OpenERX.Core.Customers
{
    public partial class Customer
    {
        public static async Task<Customer> CreateAsync(
        CustomerParams createParams,
        Credential credential,
        IResultService resultService)
        {
            if (createParams is null)
                resultService.AddMessage(new ResultMessage(ResultMessageTypes.Error, "Parâmentros Inválidos"));

            if (string.IsNullOrWhiteSpace(createParams?.Name))
                resultService.AddMessage(new ResultMessage(ResultMessageTypes.Error, "Nome Inválido"));

            if (string.IsNullOrWhiteSpace(createParams?.Identity))
                resultService.AddMessage(new ResultMessage(ResultMessageTypes.Error, "CPF/CNPJ Inválido"));

            if (resultService.HasErrors())
                return null;


            var model = new Customer();

            model.CreationDate = DateTime.UtcNow;
            model.CreationUserId = credential.UserId;
            model.CreationUserName = credential.UserName;

            model.StatusDate = DateTime.UtcNow;

            model.RecordStatusCode = CustomerStatus.Active.Code;
            model.RecordStatusName = CustomerStatus.Active.Name;

            model.PreviousId = model.VersionId;
            model.VersionId = Guid.NewGuid();
            model.VersionDate = DateTime.UtcNow;

            //model.SetFullAssociation(credential);

            //model.TypeCode = createParams.TypeCode ?? 0;
            model.Name = createParams.Name;
            model.Nickname = createParams.Nickname;
            model.Display = createParams.Display;
            model.BirthDate = DateFunctions.GetDateTimeNullable(createParams.BirthDate, "yyyyMMdd");
           // model.PersonTypeCode = createParams.PersonTypeCode ?? 0;
            model.Identity = createParams.Identity;
            model.ExternalCode = createParams.ExternalCode;
            //model.Addresses = Address.CreateEntityList(createParams.Addresses);
            //model.Phones = Phone.CreateEntityList(createParams.Phones);
            //model.Emails = Email.CreateEntityList(createParams.Emails);
            //model.Sites = Site.CreateEntityList(createParams.Sites);
            //model.Fields = DataField.CreateEntityList(createParams.Fields, resultService);
            //model.StatusCode = createParams.StatusCode ?? 0;
            //model.StatusDate = DateFunctions.GetDateTimeNullable(createParams.StatusDate);
            model.StatusNote = createParams.StatusNote;
            model.OriginId = GuidFunctions.GetGuid(createParams.OriginId);
            model.Note = createParams.Note;
            model.StoreId = GuidFunctions.GetGuid(createParams.StoreId);
            model.BrokerId = GuidFunctions.GetGuid(createParams.BrokerId);

            await model.SetParamsAsync(
            createParams,
            credential,
            resultService);

            //model.Code = await settingService.GetNextCodeAsync(credential, Feature.Customer);

            //model.RecordCreate(credential);

            return model;
        }
    }
}
