using OpenERX.Commons.Types.Addresses;
using OpenERX.Commons.Types.Emails;
using OpenERX.Repositories.Shared.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Emails
{
    public class EmailRepository : IEmailRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public EmailRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<Email> InsertEmailAsync(Guid parentId, Email email)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_email]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[parent_id],")
            .AppendLine("[parent_type],")
            .AppendLine("[type_code],")
            .AppendLine("[type_name],")
            .AppendLine("[address],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@parent_id,")
            .AppendLine("@parent_type,")
            .AppendLine("@type_code,")
            .AppendLine("@type_name,")
            .AppendLine("@address,")
            .AppendLine("@note")
            .AppendLine(" )");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            this.SetParameters(parentId, email, cm);

            cm.ExecuteNonQuery();

            return email;
        }

        public async Task<Guid> DeleteAddressAsync(Guid parentId)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_email]")
                .AppendLine(" WHERE [parent_id] = @parent_id");

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@parent_id", parentId));

            cm.ExecuteNonQuery();

            connection.Close();

            return parentId;
        }

        public async Task<IList<Email>> GetAllEmailsAsync(Guid parentId)
        {
            var l = new List<Email>();

            var commandText = this.GetSelectQuery(parentId);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var email = LoadDataReader(dataReader);

                l.Add(email);
            }

            return l;
        }

        private void SetParameters(Guid parentId, Email email, SqlCommand cm)
        {
            var parentType = "Customer";

            cm.Parameters.Add(new SqlParameter("@id", email.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_id", parentId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_type", parentType.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_code", email.TypeCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_name", email.TypeName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@address", email.Address.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", email.Note.GetDbValue()));
        }

        private StringBuilder GetSelectQuery(Guid parentId)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine("[id],")
                .AppendLine("[parent_id],")
                .AppendLine("[type_code],")
                .AppendLine("[type_name],")
                .AppendLine("[address],")
                .AppendLine("[note]")
                .AppendLine("FROM [tb_email]")
                .AppendLine("WHERE parent_id = '" + parentId + "'")
                ;

            return sb;
        }

        private static Email LoadDataReader(SqlDataReader dataReader)
        {
            var email = new Email
            {
                Id = dataReader.GetGuid("id"),
                TypeCode = dataReader.GetInt32("type_code"),
                TypeName = dataReader.GetString("type_name"),
                Address = dataReader.GetString("address"),
                Note = dataReader.GetString("note")
            };

            return email;
        }

    }
}
