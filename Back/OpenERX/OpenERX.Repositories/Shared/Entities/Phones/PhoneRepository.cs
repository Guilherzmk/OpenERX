
using OpenERX.Commons.Types.Phones;
using OpenERX.Repositories.Shared.Sql;
using System.Data.SqlClient;
using System.Text;

namespace OpenERX.Repositories.Shared.Entities.Phones
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public PhoneRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<Phone> InsertPhoneAsync(Guid parentId, Phone phone)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_phone]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[parent_id],")
            .AppendLine("[parent_type],")
            .AppendLine("[type_code],")
            .AppendLine("[type_name],")
            .AppendLine("[country_code],")
            .AppendLine("[number],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@parent_id,")
            .AppendLine("@parent_type,")
            .AppendLine("@type_code,")
            .AppendLine("@type_name,")
            .AppendLine("@country_code,")
            .AppendLine("@number,")
            .AppendLine("@note")
            .AppendLine(" )");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetParameters(parentId, phone, cm);

            cm.ExecuteNonQuery();

            return phone;
        }

        public async Task<Guid> DeletePhoneAsync(Guid parentId)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_phone]")
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

        public async Task<IList<Phone>> GetAllPhonesAsync(Guid parentId)
        {
            var l = new List<Phone>();

            var commandText = this.GetSelectQuery(parentId);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var phone = LoadDataReader(dataReader);

                l.Add(phone);
            }

            return l;
        }

        private void SetParameters(Guid parentId, Phone phone, SqlCommand cm)
        {
            var parentType = "Customer";

            cm.Parameters.Add(new SqlParameter("@id", phone.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_id", parentId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_type", parentType.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_code", phone.TypeCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_name", phone.TypeName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@country_code", phone.CountryCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@number", phone.Number.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", phone.Note.GetDbValue()));

        }

        private StringBuilder GetSelectQuery(Guid parentId)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[parent_id],")
                .AppendLine(" A.[parent_type],")
                .AppendLine(" A.[type_code],")
                .AppendLine(" A.[type_name],")
                .AppendLine(" A.[country_code],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_phone] AS A")
                .AppendLine(" WHERE A.parent_id = '" + parentId + "'");

            return sb;
        }

        private static Phone LoadDataReader(SqlDataReader dataReader)
        {
            var phone = new Phone
            {
                Id = dataReader.GetGuid("id"),
                TypeCode = dataReader.GetInt32("type_code"),
                TypeName = dataReader.GetString("type_name"),
                CountryCode = dataReader.GetString("country_code"),
                Number = dataReader.GetString("number"),
                Note = dataReader.GetString("note")
            };

            return phone;
        }

    }
}
