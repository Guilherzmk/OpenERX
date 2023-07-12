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

        public async Task<ProfileAuth> InsertProfileAuthAsync(Guid parentId, string parentType, ProfileAuth profile)
        {
            var commandText = new StringBuilder()
                .AppendLine("INSERT INTO [tb_profile_auths]")
                .AppendLine("(")
                .AppendLine("[id],")
                .AppendLine("[parent_id],")
                .AppendLine("[parent_type],")
                .AppendLine("[code],")
                .AppendLine("[name],")
                .AppendLine("[note]")
                .AppendLine(")")
                .AppendLine("VALUES")
                .AppendLine("(")
                .AppendLine("@id,")
                .AppendLine("@parent_id,")
                .AppendLine("@parent_type,")
                .AppendLine("@code,")
                .AppendLine("@name,")
                .AppendLine("@note")
                .AppendLine(")");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@code", InsertCode()));

            this.SetParameters(parentId,parentType, profile, cm);

            cm.ExecuteNonQuery();

            return profile;
        }

        public async Task<ProfileAuth> Get(Guid id)
        {
            try
            {
                var commandText = GetSelectQuery()
                    .AppendLine(" WHERE [id] = @id");

                var connection = new SqlConnection(_connectionProvider.ConnectionString);
                connection.Open();
                var cm = connection.CreateCommand();

                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@id", id));

                var dataReader = cm.ExecuteReader();

                ProfileAuth profile = null;

                while (dataReader.Read())
                {
                    profile = LoadDataReader(dataReader);
                }

                return profile;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<bool> Verification(string role, string authorization)
        {
            var l = new ProfileAuth();

            var commandText = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[parent_id],")
                .AppendLine(" A.[parent_type],")
                .AppendLine(" A.[code],")
                .AppendLine(" A.[name],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_profile_auths] AS A")
                .AppendLine(" WHERE A.parent_type = '" + role + "'");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var profileAuth = LoadDataReader(dataReader);

                if (profileAuth.Name == authorization)
                {
                    string auth = profileAuth.Name;
                    return true;
                }
            }
            return false;
        }



        private void SetParameters(Guid parentId, string parentType, ProfileAuth profile, SqlCommand cm)
        {
            
            cm.Parameters.Add(new SqlParameter("@id", profile.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_id", parentId));
            cm.Parameters.Add(new SqlParameter("@parent_type", parentType));
            cm.Parameters.Add(new SqlParameter("@name", profile.Name.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", profile.Note.GetDbValue()));
        }

        private int InsertCode()
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT COUNT([code])")
                .AppendLine(" FROM tb_profile_auths");

            var connection = new SqlConnection(_connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = sb.ToString();

            var code = Convert.ToInt32(cm.ExecuteScalar());

            code++;

            return code;
        }

        private StringBuilder GetSelectQuery()
        {
            var sb = new StringBuilder()
            .AppendLine(" SELECT")
            .AppendLine(" A.[id],")
            .AppendLine(" A.[parent_id]")
            .AppendLine(" A.[parent_type]")
            .AppendLine(" A.[code],")
            .AppendLine(" A.[name],")
            .AppendLine(" A.[note]")
            .AppendLine(" FROM [tb_profile_auths] AS A");

            return sb;
        }

        private static ProfileAuth LoadDataReader(SqlDataReader dataReader)
        {
            var profile = new ProfileAuth();

            profile.Id = dataReader.GetGuid("id");
            profile.Code = dataReader.GetInt32("code");
            profile.Name = dataReader.GetString("name");
            profile.Note = dataReader.GetString("note");

            return profile;
        }



    }
}
