using OpenERX.Core.Profiles;
using OpenERX.Core.Profiles.ProfileAuths;
using OpenERX.Repositories.Shared.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Profiles.ProfileAuths
{
    public class ProfileAuthRepository : IProfileAuthRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public ProfileAuthRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<bool> Verification(Guid profileId, Guid authorization)
        {
            var l = new ProfileAuth();

            var commandText = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[profile_id],")
                .AppendLine(" A.[auth_id]")
                .AppendLine(" FROM [tb_profile_auths] AS A")
                .AppendLine(" WHERE A.profile_id = '" + profileId + "'");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var profileAuth = LoadDataReader(dataReader);

                if (profileAuth.AuthId == authorization)
                {
                    var auth = profileAuth.AuthId;
                    return true;
                }
            }
            return false;
        }


        private static ProfileAuth LoadDataReader(SqlDataReader dataReader)
        {
            var profile = new ProfileAuth();

            profile.ProfileId = dataReader.GetGuid("profile_id");
            profile.AuthId = dataReader.GetGuid("auth_id");

            return profile;
        }



    }
}
