
using OpenERX.Commons.Types.Addresses;
using OpenERX.Repositories.Shared.Sql;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OpenERX.Repositories.Shared.Entities.Addresses
{
    public class AddressRepository : IAddressRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public AddressRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<Address> InsertAddressAsync(Guid parentId, Address address)
        {
            if(address.ZipCode is null)
            {
                return null;
            }


            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_address]")
            .AppendLine(" (")
            .AppendLine("[id],")
            .AppendLine("[parent_id],")
            .AppendLine("[parent_type],")
            .AppendLine("[type_code],")
            .AppendLine("[type_name],")
            .AppendLine("[prefix],")
            .AppendLine("[street],")
            .AppendLine("[number],")
            .AppendLine("[complement],")
            .AppendLine("[district],")
            .AppendLine("[city],")
            .AppendLine("[state],")
            .AppendLine("[country],")
            .AppendLine("[zip_code],")
            .AppendLine("[index],")
            .AppendLine("[note]")
            .AppendLine(" )")
            .AppendLine(" VALUES")
            .AppendLine(" (")
            .AppendLine("@id,")
            .AppendLine("@parent_id,")
            .AppendLine("@parent_type,")
            .AppendLine("@type_code,")
            .AppendLine("@type_name,")
            .AppendLine("@prefix,")
            .AppendLine("@street,")
            .AppendLine("@number,")
            .AppendLine("@complement,")
            .AppendLine("@district,")
            .AppendLine("@city,")
            .AppendLine("@state,")
            .AppendLine("@country,")
            .AppendLine("@zip_code,")
            .AppendLine("@index,")
            .AppendLine("@note")
            .AppendLine(" )");

            using var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();
            
            this.SetParameters(parentId, address, cm);

            cm.ExecuteNonQuery();

            return address;
        }
            
        public async Task<Guid> DeleteAddressAsync(Guid parentId)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_address]")
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

        public async Task<IList<Address>> GetAllAddressesAsync(Guid parentId)
        {
            var l = new List<Address>();

            var commandText = this.GetSelectQuery(parentId);

            var connection = new SqlConnection(this._connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            var dataReader = cm.ExecuteReader();

            while (dataReader.Read())
            {
                var address = LoadDataReader(dataReader);

                l.Add(address);
            }

            return l;
        }

        private void SetParameters(Guid parentId, Address address, SqlCommand cm)
        {
            var parentType = "Customer";

            cm.Parameters.Add(new SqlParameter("@id", address.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_id", parentId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_type", parentType.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_code", address.TypeCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_name", address.TypeName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@prefix", address.Prefix.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@street", address.Street.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@number", address.Number.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@complement", address.Complement.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@district", address.District.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@city", address.City.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@state", address.State.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@country", address.Country.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@zip_code", address.ZipCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@index", address.Index.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", address.Note.GetDbValue()));
        }

        public StringBuilder GetSelectQuery(Guid parentId)
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT")
                .AppendLine(" A.[id],")
                .AppendLine(" A.[parent_id],")
                .AppendLine(" A.[parent_type],")
                .AppendLine(" A.[type_code],")
                .AppendLine(" A.[type_name],")
                .AppendLine(" A.[prefix],")
                .AppendLine(" A.[street],")
                .AppendLine(" A.[number],")
                .AppendLine(" A.[complement],")
                .AppendLine(" A.[district],")
                .AppendLine(" A.[city],")
                .AppendLine(" A.[state],")
                .AppendLine(" A.[country],")
                .AppendLine(" A.[zip_code],")
                .AppendLine(" A.[index],")
                .AppendLine(" A.[note]")
                .AppendLine(" FROM [tb_address] AS A")
                .AppendLine(" WHERE A.parent_id = '" + parentId + "'");

            return sb;
        }

        public static Address LoadDataReader(SqlDataReader dataReader)
        {
            var address = new Address
            {
                Id = dataReader.GetGuid("id"),
                ParentType = dataReader.GetString("parent_type"),
                TypeCode = dataReader.GetInt32("type_code"),
                TypeName = dataReader.GetString("type_name"),
                Street = dataReader.GetString("street"),
                Number = dataReader.GetString("number"),
                Complement = dataReader.GetString("complement"),
                District = dataReader.GetString("district"),
                City = dataReader.GetString("city"),
                State = dataReader.GetString("state"),
                Country = dataReader.GetString("country"),
                ZipCode = dataReader.GetString("zip_code"),
                Index = dataReader.GetInt32("index"),
                Note = dataReader.GetString("note")
            };
            return address;
        }
    }
}
