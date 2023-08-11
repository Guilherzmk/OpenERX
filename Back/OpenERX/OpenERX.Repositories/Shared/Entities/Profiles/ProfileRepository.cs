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

        public async Task<Profile> InsertProfileAsync(Profile profile)
        {
            var commandText = new StringBuilder()
                .AppendLine("INSERT INTO [tb_profile]")
                .AppendLine("(")
                .AppendLine("[id],")
                .AppendLine("[code],")
                .AppendLine("[name],")
                .AppendLine("[note],")
                .AppendLine("[creation_date],")
                .AppendLine("[exclusion_date],")
                .AppendLine("[record_status_code],")
                .AppendLine("[record_status_name]")
                .AppendLine(")")
                .AppendLine("VALUES")
                .AppendLine("(")
                .AppendLine("@id,")
                .AppendLine("@code,")
                .AppendLine("@name,")
                .AppendLine("@note,")
                .AppendLine("@creation_date,")
                .AppendLine("@exclusion_date,")
                .AppendLine("@record_status_code,")
                .AppendLine("@record_status_name")
                .AppendLine(")");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@code", InsertCode()));

            this.SetParameters(profile, cm);

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

        public async Task<IList<Profile>> Find()
        {
            var l = new List<Profile>();

            var commandText = GetSelectQuery()
                .AppendLine("WHERE [record_status_code] = 1")
                .AppendLine("ORDER BY [code] ASC");

            var connection = new SqlConnection(_connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var customer = LoadDataReader(dataReader);
                l.Add(customer);
            }

            return l;
        }

        private void SetParameters(Profile profile, SqlCommand cm)
        {
            cm.Parameters.Add(new SqlParameter("@id", profile.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@name", profile.Name.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", profile.Note.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@creation_date", profile.CreationDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@exclusion_date", profile.ExclusionDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@record_status_code", profile.RecordStatusCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@record_status_name", profile.RecordStatusName.GetDbValue()));

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
            .AppendLine(" A.[name],")
            .AppendLine(" A.[note],")
            .AppendLine(" A.[creation_date],")
            .AppendLine(" A.[exclusion_date],")
            .AppendLine(" A.[record_status_code],")
            .AppendLine(" A.[record_status_name]")
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
