using OpenERX.Core.Customers;
using OpenERX.Core.Profiles;
using OpenERX.Repositories.Shared.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Profiles
{
    public class ProfileRepository : IProfileRepository
    {

        private readonly SqlConnectionProvider _connectionProvider;

        public ProfileRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<Profile> InsertProfileAsync(Guid parentId, Profile profile)
        {
            var commandText = new StringBuilder()
                .AppendLine("INSERT INTO [tb_profile]")
                .AppendLine("(")
                .AppendLine("[id],")
                .AppendLine("[code],")
                .AppendLine("[parent_id],")
                .AppendLine("[parent_type],")
                .AppendLine("[name],")
                .AppendLine("[note]")
                .AppendLine(")")
                .AppendLine("VALUES")
                .AppendLine("(")
                .AppendLine("@id,")
                .AppendLine("@code,")
                .AppendLine("@parent_id,")
                .AppendLine("@parent_type,")
                .AppendLine("@name,")
                .AppendLine("@note")
                .AppendLine(")");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@code", InsertCode()));

            this.SetParameters(parentId, profile, cm);

            cm.ExecuteNonQuery();

            return profile;
        }

        public async Task<Profile> Get(Guid id)
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

                Profile profile = null;

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


        private void SetParameters(Guid parentId, Profile profile, SqlCommand cm)
        {
            var parentType = "User";

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
                .AppendLine(" FROM tb_profile");

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
            .AppendLine(" A.[code],")
            .AppendLine(" A.[parent_id],")
            .AppendLine(" A.[parent_type],")
            .AppendLine(" A.[name],")
            .AppendLine(" A.[note]")
            .AppendLine(" FROM [tb_profile] AS A"); 

            return sb;
        }
        
        private static Profile LoadDataReader(SqlDataReader dataReader)
        {
            var profile = new Profile();

            profile.Id = dataReader.GetGuid("id");
            profile.Code = dataReader.GetInt32("code");
            profile.Name = dataReader.GetString("name");
            profile.Note = dataReader.GetString("note");

            return profile;
        }

    }
}
