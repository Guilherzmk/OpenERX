namespace OpenERX.Core.Users
{
    public partial class User
    {
        public static async Task<User> Create(UserParams createParams)
        {
            var model = new User();

            model.Name = createParams.Name;
            model.AccessKey = createParams.AccessKey;
            model.Password = createParams.Password;
            model.Email = createParams.Email;
            model.Phone = createParams.Phone;
            model.TypeCode = createParams.TypeCode;
            model.TypeName = createParams.TypeName;
            model.ProfileName = createParams.ProfileName;
            model.StatusCode = createParams.StatusCode;
            model.StatusName = createParams.StatusName;
            model.Avatar = createParams.Avatar;
            model.Note = createParams.Note;
            model.BrokerId = createParams.BrokerId;
            model.AccountId = createParams.AccountId;
            model.ProfileId = Guid.Parse("76BB72BB-16CA-4339-8204-C21C828AF779");
            model.ProfileName = "Admin";
            model.CreationDate = DateTime.UtcNow;
            model.CreationUserId = Guid.NewGuid();
            model.CreationUserName = model.Name;
            model.Enabled = true;



            return model;


        }

        


    }
}
