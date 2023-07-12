// COMPANY: Ajinsoft
// AUTHOR: Uilan Coqueiro
// DATE: 2023-05-31

using System.Data;
using System.Data.SqlClient;
using System.Text;
using OpenERX.Core.Customers;
using OpenERX.Core.Shared.Types;
using OpenERX.Repositories.Shared.Entities.Addresses;
using OpenERX.Repositories.Shared.Entities.Emails;
using OpenERX.Repositories.Shared.Entities.Fields;
using OpenERX.Repositories.Shared.Entities.Phones;
using OpenERX.Repositories.Shared.Entities.Sites;
using OpenERX.Repositories.Shared.Sql;

namespace OpenERX.Repositories.Customers
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SqlConnectionProvider _connectionProvider;
        private readonly IAddressRepository addressRepository;
        private readonly IPhoneRepository phoneRepository;
        private readonly IEmailRepository emailRepository;
        private readonly ISiteRepository siteRepository;
        private readonly IFieldsRepository fieldsRepository;

        public CustomerRepository(SqlConnectionProvider connectionProvider,
             IAddressRepository addressRepository,
             IPhoneRepository phoneRepository,
             IEmailRepository emailRepository,
             ISiteRepository siteRepository,
             IFieldsRepository fieldsRepository)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection cn = new SqlConnection();
            this.addressRepository = addressRepository;
            this.phoneRepository = phoneRepository;
            this.emailRepository = emailRepository;
            this.siteRepository = siteRepository;
            this.fieldsRepository = fieldsRepository;
            _connectionProvider = connectionProvider;

            //cn.Open();
            //cn.OpenAsync();
        }

        public async Task<Customer> InsertAsync(Customer customer)
        {
            var commandText = new StringBuilder()
                .AppendLine(" INSERT INTO [tb_customer]")
                .AppendLine(" (")
                .AppendLine(" [id],")
                .AppendLine(" [code],")
                .AppendLine(" [type_code],")
                .AppendLine(" [type_name],")
                .AppendLine(" [name],")
                .AppendLine(" [nickname],")
                .AppendLine(" [display],")
                .AppendLine(" [birth_date],")
                .AppendLine(" [person_type_code],")
                .AppendLine(" [person_type_name],")
                .AppendLine(" [identity],")
                .AppendLine(" [external_code],")
                .AppendLine(" [status_code],")
                .AppendLine(" [status_name],")
                .AppendLine(" [status_date],")
                .AppendLine(" [status_color],")
                .AppendLine(" [status_note],")
                .AppendLine(" [origin_id],")
                .AppendLine(" [origin_code],")
                .AppendLine(" [origin_name],")
                .AppendLine(" [note],")
                .AppendLine(" [account_id],")
                .AppendLine(" [account_code],")
                .AppendLine(" [account_name],")
                .AppendLine(" [store_id],")
                .AppendLine(" [store_code],")
                .AppendLine(" [store_name],")
                .AppendLine(" [broker_id],")
                .AppendLine(" [broker_code],")
                .AppendLine(" [broker_name],")
                .AppendLine(" [creation_date],")
                .AppendLine(" [creation_user_id],")
                .AppendLine(" [creation_user_name],")
                .AppendLine(" [change_date],")
                .AppendLine(" [change_user_id],")
                .AppendLine(" [change_user_name],")
                .AppendLine(" [exclusion_date],")
                .AppendLine(" [exclusion_user_id],")
                .AppendLine(" [exclusion_user_name],")
                .AppendLine(" [record_status_code],")
                .AppendLine(" [record_status_name],")
                .AppendLine(" [version_id],")
                .AppendLine(" [previous_id],")
                .AppendLine(" [version_date]")
                .AppendLine(" )")
                .AppendLine(" VALUES")
                .AppendLine(" (")
                .AppendLine(" @id,")
                .AppendLine(" @code,")
                .AppendLine(" @type_code,")
                .AppendLine(" @type_name,")
                .AppendLine(" @name,")
                .AppendLine(" @nickname,")
                .AppendLine(" @display,")
                .AppendLine(" @birth_date,")
                .AppendLine(" @person_type_code,")
                .AppendLine(" @person_type_name,")
                .AppendLine(" @identity,")
                .AppendLine(" @external_code,")
                .AppendLine(" @status_code,")
                .AppendLine(" @status_name,")
                .AppendLine(" @status_date,")
                .AppendLine(" @status_color,")
                .AppendLine(" @status_note,")
                .AppendLine(" @origin_id,")
                .AppendLine(" @origin_code,")
                .AppendLine(" @origin_name,")
                .AppendLine(" @note,")
                .AppendLine(" @account_id,")
                .AppendLine(" @account_code,")
                .AppendLine(" @account_name,")
                .AppendLine(" @store_id,")
                .AppendLine(" @store_code,")
                .AppendLine(" @store_name,")
                .AppendLine(" @broker_id,")
                .AppendLine(" @broker_code,")
                .AppendLine(" @broker_name,")
                .AppendLine(" @creation_date,")
                .AppendLine(" @creation_user_id,")
                .AppendLine(" @creation_user_name,")
                .AppendLine(" @change_date,")
                .AppendLine(" @change_user_id,")
                .AppendLine(" @change_user_name,")
                .AppendLine(" @exclusion_date,")
                .AppendLine(" @exclusion_user_id,")
                .AppendLine(" @exclusion_user_name,")
                .AppendLine(" @record_status_code,")
                .AppendLine(" @record_status_name,")
                .AppendLine(" @version_id,")
                .AppendLine(" @previous_id,")
                .AppendLine(" @version_date")
                .AppendLine(" )");

            using var connection = new SqlConnection(_connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();
            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@code", InsertCode()));

            SetParameters(customer, cm);

            cm.ExecuteNonQuery();

            foreach (var address in customer.Addresses)
            {
                await addressRepository.InsertAddressAsync(customer.Id, address);
            }

            foreach (var phone in customer.Phones)
            {
                await phoneRepository.InsertPhoneAsync(customer.Id, phone);
            }

            foreach (var email in customer.Emails)
            {
                await emailRepository.InsertEmailAsync(customer.Id, email);
            }

            foreach (var site in customer.Sites)
            {
                await siteRepository.InsertSiteAsync(customer.Id, site);
            }

            foreach (var fields in customer.Fields)
            {
                await fieldsRepository.InsertFieldAsync(customer.Id, fields);
            }

            return customer;
        }

        public Task InsertManyAsync(IList<Customer> customers)
        {
            throw new NotImplementedException();
        }

        public async Task<long> UpdateAsync(Customer customer)
        {
            var commandText = new StringBuilder()
                .AppendLine(" UPDATE [tb_customer]")
                .AppendLine(" SET")
                .AppendLine(" [id] = @id,")
                .AppendLine(" [type_code] = @type_code,")
                .AppendLine(" [type_name] = @type_name,")
                .AppendLine(" [name] = @name,")
                .AppendLine(" [nickname] = @nickname,")
                .AppendLine(" [display] = @display,")
                .AppendLine(" [birth_date] = @birth_date,")
                .AppendLine(" [person_type_code] = @person_type_code,")
                .AppendLine(" [person_type_name] = @person_type_name,")
                .AppendLine(" [identity] = @identity,")
                .AppendLine(" [external_code] = @external_code,")
                .AppendLine(" [status_code] = @status_code,")
                .AppendLine(" [status_name] = @status_name,")
                .AppendLine(" [status_date] = @status_date,")
                .AppendLine(" [status_color] = @status_color,")
                .AppendLine(" [status_note] = @status_note,")
                .AppendLine(" [origin_id] = @origin_id,")
                .AppendLine(" [origin_code] = @origin_code,")
                .AppendLine(" [origin_name] = @origin_name,")
                .AppendLine(" [note] = @note,")
                .AppendLine(" [account_id] = @account_id,")
                .AppendLine(" [account_code] = @account_code,")
                .AppendLine(" [account_name] = @account_name,")
                .AppendLine(" [store_id] = @store_id,")
                .AppendLine(" [store_code] = @store_code,")
                .AppendLine(" [store_name] = @store_name,")
                .AppendLine(" [broker_id] = @broker_id,")
                .AppendLine(" [broker_code] = @broker_code,")
                .AppendLine(" [broker_name] = @broker_name,")
                .AppendLine(" [creation_date] = @creation_date,")
                .AppendLine(" [creation_user_id] = @creation_user_id,")
                .AppendLine(" [creation_user_name] = @creation_user_name,")
                .AppendLine(" [change_date] = @change_date,")
                .AppendLine(" [change_user_id] = @change_user_id,")
                .AppendLine(" [change_user_name] = @change_user_name,")
                .AppendLine(" [exclusion_date] = @exclusion_date,")
                .AppendLine(" [exclusion_user_id] = @exclusion_user_id,")
                .AppendLine(" [exclusion_user_name] = @exclusion_user_name,")
                .AppendLine(" [record_status_code] = @record_status_code,")
                .AppendLine(" [record_status_name] = @record_status_name,")
                .AppendLine(" [version_id] = @version_id,")
                .AppendLine(" [previous_id] = @previous_id,")
                .AppendLine(" [version_date] = @version_date")
                .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(_connectionProvider.ConnectionString);
            connection.Open();

            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            SetParameters(customer, cm);

            cm.ExecuteNonQuery();

            addressRepository.DeleteAddressAsync(customer.Id);
            foreach (var address in customer.Addresses)
            {
                addressRepository.InsertAddressAsync(customer.Id, address);
            }

            emailRepository.DeleteAddressAsync(customer.Id);
            foreach (var email in customer.Emails)
            {
                emailRepository.InsertEmailAsync(customer.Id, email);
            }

            phoneRepository.DeletePhoneAsync(customer.Id);
            foreach (var phone in customer.Phones)
            {
                phoneRepository.InsertPhoneAsync(customer.Id, phone);
            }

            siteRepository.DeleteSiteAsync(customer.Id);
            foreach (var site in customer.Sites)
            {
                siteRepository.InsertSiteAsync(customer.Id, site);
            }

            fieldsRepository.DeleteFieldAsync(customer.Id);
            foreach (var field in customer.Fields)
            {
                fieldsRepository.InsertFieldAsync(customer.Id, field);
            }

            return customer.Code;
        }

        public async Task<long> DeleteAsync(Guid id)
        {
            try
            {
                var commandText = new StringBuilder()
                    .AppendLine(" UPDATE [tb_customer]")
                    .AppendLine(" SET")
                    .AppendLine(" [exclusion_date] = @exclusion_date,")
                    .AppendLine(" [record_status_code] = @record_status_code,")
                    .AppendLine(" [record_status_name] = @record_status_name,")
                    .AppendLine(" [previous_id] = @version_id,")
                    .AppendLine(" [version_id] = @version_id,")
                    .AppendLine(" [version_date] = @version_date")
                    .AppendLine(" WHERE [id] = @id")
                    ;

                var connection = new SqlConnection(_connectionProvider.ConnectionString);
                connection.Open();
                var cm = connection.CreateCommand();

                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@id", id));
                cm.Parameters.Add(new SqlParameter("@record_status_code", CustomerStatus.Disabled.Code));
                cm.Parameters.Add(new SqlParameter("@record_status_name", CustomerStatus.Disabled.Name));
                cm.Parameters.Add(new SqlParameter("@exclusion_date", DateTime.UtcNow));
                cm.Parameters.Add(new SqlParameter("@version_id", Guid.NewGuid()));
                cm.Parameters.Add(new SqlParameter("@version_date", DateTime.UtcNow));

                cm.ExecuteNonQuery();

                return 1;
            }
            catch (Exception e)
            {
                return 0;
            }

        }

        public async Task<Customer> GetAsync(Guid id)
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

                Customer customer = null;

                while (dataReader.Read())
                {
                    customer = LoadDataReader(dataReader);
                }

                customer.Addresses = await addressRepository.GetAllAddressesAsync(customer.Id);
                customer.Emails = await emailRepository.GetAllEmailsAsync(customer.Id);
                customer.Phones = await phoneRepository.GetAllPhonesAsync(customer.Id);
                customer.Sites = await siteRepository.GetAllSitesAsync(customer.Id);

                return customer;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<Customer> GetAsync(int accountCode, Guid id)
        {
            var commandText = GetSelectQuery()
                    .AppendLine(" WHERE [id] = @id");

            var connection = new SqlConnection(_connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = commandText.ToString();

            cm.Parameters.Add(new SqlParameter("@id", id));

            var dataReader = cm.ExecuteReader();

            Customer customer = null;

            while (dataReader.Read())
            {
                customer = LoadDataReader(dataReader);
            }

            customer.Addresses = await addressRepository.GetAllAddressesAsync(customer.Id);

            return customer;
        }

        public async Task<long> StatusUpdateAsync(Guid id, StatusType status)
        {
            if (status == StatusType.Active)
            {
                var commandText = new StringBuilder()
                    .AppendLine(" UPDATE [tb_customer]")
                    .AppendLine(" SET")
                    .AppendLine(" [change_date] = @change_date,")
                    .AppendLine(" [record_status_code] = @record_status_code,")
                    .AppendLine(" [record_status_name] = @record_status_name")
                    .AppendLine(" WHERE [id] = @id");

                var connection = new SqlConnection(_connectionProvider.ConnectionString);
                connection.Open();
                var cm = connection.CreateCommand();

                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@id", id));
                cm.Parameters.Add(new SqlParameter("@change_date", DateTime.UtcNow));
                cm.Parameters.Add(new SqlParameter("@record_status_code", CustomerStatus.Active.Code));
                cm.Parameters.Add(new SqlParameter("@record_status_name", CustomerStatus.Active.Name));

                cm.ExecuteNonQuery();
            }
            else if (status == StatusType.Disabled)
            {
                var commandText = new StringBuilder()
                    .AppendLine(" UPDATE [tb_customer]")
                    .AppendLine(" SET")
                    .AppendLine(" [change_date] = @change_date,")
                    .AppendLine(" [record_status_code] = @record_status_code,")
                    .AppendLine(" [record_status_name] = @record_status_name,")
                    .AppendLine(" WHERE [id] = @id");

                var connection = new SqlConnection(_connectionProvider.ConnectionString);
                connection.Open();
                var cm = connection.CreateCommand();

                cm.CommandText = commandText.ToString();

                cm.Parameters.Add(new SqlParameter("@id", id));
                cm.Parameters.Add(new SqlParameter("@change_date", DateTime.UtcNow));
                cm.Parameters.Add(new SqlParameter("@record_status_code", CustomerStatus.Disabled.Code));
                cm.Parameters.Add(new SqlParameter("@record_status_name", CustomerStatus.Disabled.Name));

                cm.ExecuteNonQuery();
            }

            return 1;
        }

        public async Task<IList<Customer>> FindAsync()
        {
            var l = new List<Customer>();

            var commandText = GetSelectQuery()
                .AppendLine(" WHERE [record_status_code] = 1")
                .AppendLine(" ORDER BY [code] ASC");

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

        private void SetParameters(Customer customer, SqlCommand cm)
        {
            cm.Parameters.Add(new SqlParameter("@id", customer.Id.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_code", customer.TypeCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@type_name", customer.TypeName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@name", customer.Name.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@nickname", customer.Nickname.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@display", customer.Display.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@birth_date", customer.BirthDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@person_type_code", customer.PersonTypeCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@person_type_name", customer.PersonTypeName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@identity", customer.Identity.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@external_code", customer.ExternalCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@status_code", customer.StatusCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@status_name", customer.StatusName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@status_date", customer.StatusDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@status_color", customer.StatusColor.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@status_note", customer.StatusNote.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@origin_id", customer.OriginId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@origin_code", customer.OriginCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@origin_name", customer.OriginName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@note", customer.Note.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@account_id", customer.AccountId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@account_code", customer.AccountCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@account_name", customer.AccountName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@store_id", customer.StoreId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@store_code", customer.StoreCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@store_name", customer.StoreName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@broker_id", customer.BrokerId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@broker_code", customer.BrokerCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@broker_name", customer.BrokerName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@creation_date", customer.CreationDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@creation_user_id", customer.CreationUserId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@creation_user_name", customer.CreationUserName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@change_date", customer.ChangeDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@change_user_id", customer.ChangeUserId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@change_user_name", customer.ChangeUserName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@exclusion_date", customer.ExclusionDate.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@exclusion_user_id", customer.ExclusionUserId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@exclusion_user_name", customer.ExclusionUserName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@record_status_code", customer.RecordStatusCode.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@record_status_name", customer.RecordStatusName.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@version_id", customer.VersionId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@previous_id", customer.PreviousId.GetDbValue()));
            cm.Parameters.Add(new SqlParameter("@version_date", customer.VersionDate.GetDbValue()));
        }

        private StringBuilder GetSelectQuery()
        {
            var sb = new StringBuilder()
            .AppendLine(" SELECT")
            .AppendLine(" A.[id],")
            .AppendLine(" A.[code],")
            .AppendLine(" A.[type_code],")
            .AppendLine(" A.[type_name],")
            .AppendLine(" A.[name],")
            .AppendLine(" A.[nickname],")
            .AppendLine(" A.[display],")
            .AppendLine(" A.[birth_date],")
            .AppendLine(" A.[person_type_code],")
            .AppendLine(" A.[person_type_name],")
            .AppendLine(" A.[identity],")
            .AppendLine(" A.[external_code],")
            .AppendLine(" A.[status_code],")
            .AppendLine(" A.[status_name],")
            .AppendLine(" A.[status_date],")
            .AppendLine(" A.[status_color],")
            .AppendLine(" A.[status_note],")
            .AppendLine(" A.[origin_id],")
            .AppendLine(" A.[origin_code],")
            .AppendLine(" A.[origin_name],")
            .AppendLine(" A.[note],")
            .AppendLine(" A.[account_id],")
            .AppendLine(" A.[account_code],")
            .AppendLine(" A.[account_name],")
            .AppendLine(" A.[store_id],")
            .AppendLine(" A.[store_code],")
            .AppendLine(" A.[store_name],")
            .AppendLine(" A.[broker_id],")
            .AppendLine(" A.[broker_code],")
            .AppendLine(" A.[broker_name],")
            .AppendLine(" A.[creation_date],")
            .AppendLine(" A.[creation_user_id],")
            .AppendLine(" A.[creation_user_name],")
            .AppendLine(" A.[change_date],")
            .AppendLine(" A.[change_user_id],")
            .AppendLine(" A.[change_user_name],")
            .AppendLine(" A.[exclusion_date],")
            .AppendLine(" A.[exclusion_user_id],")
            .AppendLine(" A.[exclusion_user_name],")
            .AppendLine(" A.[record_status_code],")
            .AppendLine(" A.[record_status_name],")
            .AppendLine(" A.[version_id],")
            .AppendLine(" A.[previous_id],")
            .AppendLine(" A.[version_date]")
            .AppendLine(" FROM [tb_customer] AS A");

            return sb;
        }

        private static Customer LoadDataReader(SqlDataReader dataReader)
        {
            var customer = new Customer();

            customer.Id = dataReader.GetGuid("id");
            customer.Code = dataReader.GetInt32("code");
            customer.TypeCode = dataReader.GetInt32("type_code");
            customer.TypeName = dataReader.GetString("type_name");
            customer.Name = dataReader.GetString("name");
            customer.Nickname = dataReader.GetString("nickname");
            customer.Display = dataReader.GetString("display");
            customer.BirthDate = dataReader.GetDateTime("birth_date");
            customer.PersonTypeCode = dataReader.GetInt32("person_type_code");
            customer.PersonTypeName = dataReader.GetString("persont_type_name");
            customer.Identity = dataReader.GetString("identity");
            customer.StatusCode = dataReader.GetInt32("status_code");
            customer.StatusName = dataReader.GetString("status_name");
            customer.StatusDate = dataReader.GetDateTime("status_date");
            customer.StatusColor = dataReader.GetString("status_color");
            customer.StatusNote = dataReader.GetString("status_note");
            customer.OriginId = dataReader.GetGuid("origin_id");
            customer.OriginCode = dataReader.GetInt32("origin_code");
            customer.OriginName = dataReader.GetString("origin_name");
            customer.Note = dataReader.GetString("note");
            customer.AccountId = dataReader.GetGuid("account_id");
            customer.AccountCode = dataReader.GetInt32("account_code");
            customer.AccountName = dataReader.GetString("account_name");
            customer.StoreId = dataReader.GetGuid("store_id");
            customer.StoreCode = dataReader.GetInt32("store_code");
            customer.StoreName = dataReader.GetString("store_name");
            customer.BrokerId = dataReader.GetGuid("broker_id");
            customer.BrokerCode = dataReader.GetInt32("broker_code");
            customer.BrokerName = dataReader.GetString("broker_name");
            customer.CreationDate = dataReader.GetDateTime("creation_date");
            customer.CreationUserId = dataReader.GetGuid("creation_user_id");
            customer.CreationUserName = dataReader.GetString("creation_user_name");
            customer.ChangeDate = dataReader.GetDateTime("change_date");
            customer.ChangeUserId = dataReader.GetGuid("change_user_id");
            customer.ChangeUserName = dataReader.GetString("change_user_name");
            customer.ExclusionDate = dataReader.GetDateTime("exclusion_date");
            customer.ExclusionUserId = dataReader.GetGuid("exclusion_user_id");
            customer.ExclusionUserName = dataReader.GetString("exclusion_user_name");
            customer.RecordStatusCode = dataReader.GetInt32("record_status_code");
            customer.RecordStatusName = dataReader.GetString("record_status_name");
            customer.VersionId = dataReader.GetGuid("version_id");
            customer.PreviousId = dataReader.GetGuid("previous_id");
            customer.VersionDate = dataReader.GetDateTime("version_date");

            return customer;
        }

        private int InsertCode()
        {
            var sb = new StringBuilder()
                .AppendLine(" SELECT COUNT([code])")
                .AppendLine(" FROM tb_customer");

            var connection = new SqlConnection(_connectionProvider.ConnectionString);
            connection.Open();
            var cm = connection.CreateCommand();

            cm.CommandText = sb.ToString();

            var code = Convert.ToInt32(cm.ExecuteScalar());

            code++;

            return code;
        }
    }
}
