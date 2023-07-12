using OpenERX.Commons.Types.Emails;
using OpenERX.Commons.Types.Sites;
using OpenERX.Repositories.Shared.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Repositories.Shared.Entities.Sites
{
    public class SiteRepository : ISiteRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;

        public SiteRepository(SqlConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        public async Task<Site> InsertSiteAsync(Guid parentId, Site site)
        {
            var commandText = new StringBuilder()
            .AppendLine("INSERT INTO [tb_site]")
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

            this.SetParameters(parentId, site, cm);

            cm.ExecuteNonQuery();

            return site;
        }

        public async Task<Guid> DeleteSiteAsync(Guid parentId)
        {
            var commandText = new StringBuilder()
                .AppendLine(" DELETE FROM [tb_site]")
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

        public async Task<IList<Site>> GetAllSitesAsync(Guid parentId)
        {
            var l = new List<Site>();

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

        private void SetParameters(Guid parentId, Site site, SqlCommand cm)
        {
            var parentType = "Customer";

            cm.Parameters.Add(new SqlParameter("@id", site.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_id", parentId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@parent_type", parentType.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_code", site.TypeCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_name", site.TypeName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@address", site.Address.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", site.Note.GetDbValue()));
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
                .AppendLine("FROM [tb_site]")
                .AppendLine("WHERE parent_id = '" + parentId + "'");

            return sb;
        }

        private static Site LoadDataReader(SqlDataReader dataReader)
        {
            var site = new Site
            {
                Id = dataReader.GetGuid("id"),
                TypeCode = dataReader.GetInt32("type_code"),
                TypeName = dataReader.GetString("type_name"),
                Address = dataReader.GetString("address"),
                Note = dataReader.GetString("note")
            };

            return site;
        }

    }
}
