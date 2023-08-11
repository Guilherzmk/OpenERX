using OpenERX.Core.SignIns;
using OpenERX.Core.Users;
using OpenERX.Repositories.Shared.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.SignIns
{
    public class SignInRepository : ISignInRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public SignInRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<User> Get(string accessKey)
        {
            try
            {
                var commandText = new StringBuilder()
                .AppendLine(" SELECT * FROM [tb_user]")
                .AppendLine(" WHERE [access_key] = @access_key");

                using var connection = new SqlConnection(_connectionProvider.ConnectionString);
                connection.Open();
                var cm = connection.CreateCommand();

                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@access_key", accessKey));

                var dataReader = cm.ExecuteReader();

                User user = null;

                while (dataReader.Read())
                {
                    user = LoadDataReader(dataReader);
                }

                return user;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private static User LoadDataReader(SqlDataReader dataReader)
        {
            var user = new User();

            user.Id = dataReader.GetGuid("id");
            user.Code = dataReader.GetInt32("code");
            user.Name = dataReader.GetString("name");
            user.AccessKey = dataReader.GetString("access_key");
            user.Password = dataReader.GetString("password");
            user.Email = dataReader.GetString("email");
            user.Phone = dataReader.GetString("phone");
            user.TypeCode = dataReader.GetInt32("type_code");
            user.TypeName = dataReader.GetString("type_name");
            user.ProfileId = dataReader.GetGuid("profile_id");
            user.ProfileName = dataReader.GetString("profile_name");
            user.StatusCode = dataReader.GetInt32("status_code");
            user.StatusName = dataReader.GetString("id");
            user.LastAccess = dataReader.GetDateTime("id");
            user.AccessCount = dataReader.GetInt32("id");
            user.Enabled = dataReader.GetBoolean("id");
            user.Avatar = dataReader.GetString("id");
            user.Note = dataReader.GetString("id");
            user.BrokerId = dataReader.GetGuid("id");
            user.AccountId = dataReader.GetGuid("id");
            user.CreationDate = dataReader.GetDateTime("id");
            user.CreationUserId = dataReader.GetGuid("id");
            user.CreationUserName = dataReader.GetString("id");
            user.ChangeDate = dataReader.GetDateTime("id");
            user.ChangeUserName = dataReader.GetString("id");
            user.ExclusionDate = dataReader.GetDateTime("id");
            user.ExclusionUserId = dataReader.GetGuid("id");
            user.ExclusionUserName = dataReader.GetString("id");
            user.RecordStatus = dataReader.GetInt16("id");

            return user;
        }
    }
}
