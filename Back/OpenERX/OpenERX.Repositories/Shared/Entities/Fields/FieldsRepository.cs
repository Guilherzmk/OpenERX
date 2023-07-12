using OpenERX.Commons.Types.Fields;
using OpenERX.Commons.Types.Phones;
using OpenERX.Repositories.Shared.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Fields
{
    public class FieldsRepository : IFieldsRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public FieldsRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<DataField> InsertFieldAsync(Guid parentId, DataField dataField)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_fields]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[parent_id],")
            .AppendLine("[key],")
            .AppendLine("[label],")
            .AppendLine("[type],")
            .AppendLine("[value],")
            .AppendLine("[display]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@parent_id,")
            .AppendLine("@key,")
            .AppendLine("@label,")
            .AppendLine("@type,")
            .AppendLine("@value,")
            .AppendLine("@display")
            .AppendLine(" )");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);

            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            this.SetParameters(parentId, dataField, cm);

            cm.ExecuteNonQuery();

            return dataField;
        }

        public async Task<Guid> DeleteFieldAsync(Guid parentId)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_fields]")
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

        public async Task<IList<DataField>> GetAllFieldsAsync(Guid parentId)
        {
            var l = new List<DataField>();

            var commandText = this.GetSelectQuery(parentId);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var field = LoadDataReader(dataReader);

                l.Add(field);
            }

            return l;
        }

        private void SetParameters(Guid parentId, DataField dataField, SqlCommand cm)
        {
            var parentType = "Customer";

            cm.Parameters.Add(new SqlParameter("@id", dataField.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_id", parentId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@key", dataField.Key.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@label", dataField.Label.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type", parentType.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@value", dataField.Value.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@display", dataField.Display.GetDbValue()));
        }

        private StringBuilder GetSelectQuery(Guid parentId)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[parent_id],")
                .AppendLine(" A.[key],")
                .AppendLine(" A.[label],")
                .AppendLine(" A.[type],")
                .AppendLine(" A.[value],")
                .AppendLine(" A.[display],")
                .AppendLine(" FROM [tb_fields] AS A")
                .AppendLine(" WHERE A.parent_id = '" + parentId + "'");

            return sb;
        }

        private static DataField LoadDataReader(SqlDataReader dataReader)
        {
            var phone = new DataField
            {
                Id = dataReader.GetGuid("id"),
                Key = dataReader.GetString("key"),
                Label = dataReader.GetString("label"),
                Value = dataReader.GetString("value"),
                Display = dataReader.GetString("display"),
            };

            return phone;
        }

    }
}
