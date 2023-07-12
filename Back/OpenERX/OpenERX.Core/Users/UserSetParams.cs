using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Users
{
    public static class UserSetParams
    {
        public static User SetParams(
            this User _this,
            UserParams modelParams)
        {
            if (modelParams.Name != null)
                _this.Name = modelParams.Name;

            if (modelParams.AccessKey != null)
                _this.AccessKey = modelParams.AccessKey;

            if (modelParams.Password != null)
                _this.Password = modelParams.Password;

            if (modelParams.Email != null)
                _this.Email = modelParams.Email;

            if (modelParams.Phone != null)
                _this.Phone = modelParams.Phone;

            if (modelParams.TypeCode != null)
                _this.TypeCode = modelParams.TypeCode;

            if (modelParams.TypeName != null)
                _this.TypeName = modelParams.TypeName;

            if (modelParams.ProfileCode != null)
                _this.ProfileCode = modelParams.ProfileCode;

            if (modelParams.ProfileName != null)
                _this.ProfileName = modelParams.ProfileName;

            if (modelParams.StatusCode != null)
                _this.StatusCode = modelParams.StatusCode;

            if (modelParams.StatusName != null)
                _this.StatusName = modelParams.StatusName;

            if (modelParams.Avatar != null)
                _this.Avatar = modelParams.Avatar;

            if (modelParams.Note != null)
                _this.Note = modelParams.Note;

            if (modelParams.BrokerId != null)
                _this.BrokerId = modelParams.BrokerId;

            if (modelParams.AccountId != null)
                _this.AccountId = modelParams.AccountId;

            return _this;
        }



    }
}
