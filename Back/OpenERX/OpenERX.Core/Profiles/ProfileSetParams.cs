using OpenERX.Commons.Credentials;
using OpenERX.Commons.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Profiles
{
    public static class ProfileSetParams
    {
        public static async Task<Profile> SetParamsAsync(
            this Profile _this,
            ProfileParams setParams,
            Credential credential,
            IResultService resultService)
        {
            if(setParams.Name != null)
                _this.Name = setParams.Name;

            if(setParams.Note != null)
                _this.Note = setParams.Note;

            return _this;

        }
    }
}
