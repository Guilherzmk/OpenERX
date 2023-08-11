using OpenERX.Commons.Credentials;
using OpenERX.Commons.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles
{
    public partial class Profile
    {
        public static async Task<Profile> CreateAsync(
            ProfileParams createParams,
            Credential credential,
            IResultService resultService)
        {
            if (createParams is null)
                resultService.AddMessage(new ResultMessage(ResultMessageTypes.Error, "Parâmetros Inválidos"));

            if(string.IsNullOrWhiteSpace(createParams?.Name))
                resultService.AddMessage(new ResultMessage(ResultMessageTypes.Error, "Nome Inválido"));

            if (resultService.HasErrors())
                return null;

            var model = new Profile();

            model.CreationDate = DateTime.UtcNow;
            model.RecordStatusCode = 1;
            model.RecordStatusName = "Ativo";

            await model.SetParamsAsync(
                createParams,
                credential,
                resultService);

            return model;

        }
    }
}
