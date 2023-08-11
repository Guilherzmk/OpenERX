 
using OpenERX.Commons.Credentials;
using OpenERX.Commons.Functions;
using OpenERX.Commons.Params;
using OpenERX.Commons.Results;

namespace OpenERX.Core.Customers
{
    public static class CustomerUpdateStatus
    {
        public static Customer UpdateStatus(
        this Customer _this,
        UpdateStatusParams3 statusParams,
        Credential credential,
        IResultService resultService)
        {
            var status = CustomerStatus.Get(statusParams?.Code ?? 0);

            if (resultService.AddMessage(AssertMessage.NotNull(status, new ResultMessage(ResultMessageTypes.Error, "Status Inválido"))))
                return _this;

            //_this.Status = new StatusField(
            //status.Code,
            //status.Name,
            //DateFunctions.GetDate(statusParams?.Date) ?? DateTime.Now,
            //status.Color,
            //statusParams?.Note
            //);

            //_this.RecordUpdate(credential);
            return _this;
        }
    }
}
