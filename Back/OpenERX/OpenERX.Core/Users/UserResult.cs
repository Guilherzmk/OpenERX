using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Core.Users
{
    public class UserResult
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string AccessKey { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TypeCode { get; set; }
        public string TypeName { get; set; }
        public int ProfileCode { get; set; }
        public string ProfileName { get; set; }
        public int StatusCode { get; set; }
        public string StatusName { get; set; }
        public DateTime LastAccess { get; set; }
        public int AccessCount { get; set; }
        public bool Enabled { get; set; }
        public string Avatar { get; set; }
        public string Note { get; set; }
        public Guid BrokerId { get; set; }
        public Guid AccountId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid CreationUserId { get; set; }
        public string CreationUserName { get; set; }
        public DateTime ChangeDate { get; set; }
        public Guid ChangeUserId { get; set; }
        public string ChangeUserName { get; set; }
        public DateTime ExclusionDate { get; set; }
        public Guid ExclusionUserId { get; set; }
        public string ExclusionUserName { get; set; }
        public short RecordStatus { get; set; }
        public string Token { get; set; }

        public UserResult(User model)
        {
            this.Id = model.Id;
            this.Code = model.Code;
            this.Name = model.Name;
            this.AccessKey = model.AccessKey;
            this.Password = model.Password;
            this.Email = model.Email;
            this.Phone = model.Phone;
            this.TypeCode = model.TypeCode;
            this.TypeName = model.TypeName;
            this.ProfileName = model.ProfileName;
            this.StatusCode = model.StatusCode;
            this.StatusName = model.StatusName;
            this.LastAccess = model.LastAccess;
            this.AccessCount = model.AccessCount;
            this.Enabled = model.Enabled;
            this.Avatar = model.Avatar;
            this.Note = model.Note;
            this.BrokerId = model.BrokerId;
            this.AccountId = model.AccountId;
            this.CreationDate = model.CreationDate;
            this.CreationUserId = model.CreationUserId;
            this.CreationUserName = model.CreationUserName;
            this.ChangeDate = model.ChangeDate;
            this.ChangeUserId = model.ChangeUserId;
            this.ChangeUserName = model.ChangeUserName;
            this.ExclusionDate = model.ExclusionDate;
            this.ExclusionUserId = model.ExclusionUserId;
            this.ExclusionUserName = model.ExclusionUserName;
            this.RecordStatus = model.RecordStatus;
            this.Token = model.Token;
        }



    }
}
