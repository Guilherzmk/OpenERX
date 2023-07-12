
using OpenERX.Commons.Credentials;
using OpenERX.Commons.Params;
using OpenERX.Commons.Results;
using OpenERX.Commons.Types.Results;
using OpenERX.Core.Customers;
using OpenERX.Core.Shared;
using OpenERX.Core.Shared.Types;
using OpenERX.Repositories.Shared.Entities.Profiles.ProfileAuths;

namespace OpenERX.Services.Customers
{
    public class CustomerService : ResultService, ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IProfileAuthRepository profileAuthRepository;


        public CustomerService(
            ICustomerRepository customerRepository,
            IProfileAuthRepository profileAuthRepository
        )
        {
            this.customerRepository = customerRepository;
            this.profileAuthRepository = profileAuthRepository;
        }

        public async Task<CustomerResult> CreateAsync(CustomerParams createParams, string role)
        {
            string authorization = "Create";
            var validation = await this.profileAuthRepository.Verification(role, authorization);

            if (validation == true)
            {
                var credential = new Credential();

                try
                {
                    var model = await Customer.CreateAsync(
                        createParams,
                        credential,
                        this);

                    if (this.HasErrors())
                        return null;

                    await this.customerRepository.InsertAsync(model);

                    return new CustomerResult(model);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<CustomerResult> UpdateAsync(Guid id, CustomerParams updateParams, string role)
        {
            string authorization = "Update";
            var validation = await this.profileAuthRepository.Verification(role, authorization);

            if (validation == true)
            {
                var credential = new Credential();

                try
                {

                    var model = await this.customerRepository.GetAsync(id);

                    await model.UpdateAsync(
                        updateParams,
                        credential,
                        this);

                    if (this.HasErrors())
                        return null;

                    await this.customerRepository.UpdateAsync(model);

                    return new CustomerResult(model);
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }


        }

        public async Task<CustomerResult> UpdateStatusAsync(Guid id, UpdateStatusParams3 statusParams)
        {
            var credential = new Credential();

            try
            {
                var model = await this.customerRepository.GetAsync(credential.AccountCode, id);

                model.UpdateStatus(statusParams, credential, this);

                if (this.HasErrors())
                    return null;

                await this.customerRepository.UpdateAsync(model);

                return new CustomerResult(model);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<CountResult> DeleteAsync(IdParams deleteParams, string role)
        {
            string authorization = "Delete";
            var validation = await this.profileAuthRepository.Verification(role, authorization);

            if (validation == true)
            {
                var credential = new Credential();

                try
                {

                    if (deleteParams?.Ids == null)
                        return null;

                    var result = new CountResult
                    {
                        Count = deleteParams.Ids.Count
                    };

                    foreach (var id in deleteParams.Ids)
                    {
                        var model = await this.customerRepository.GetAsync(credential.AccountCode, id);

                        await this.customerRepository.DeleteAsync(id);

                        result.Success++;
                    }

                    return result;
                }
                catch (Exception e)
                {
                    return null;
                }

            }
            else
            {
                return null;
            }


        }

        public async Task<CustomerResult> GetAsync(Guid id, string role)
        {
            string authorization = "Read";
            var validation = await this.profileAuthRepository.Verification(role, authorization);

            if (validation == true)
            {
                var credential = new Credential();

                try
                {
                    var model = await this.customerRepository.GetAsync(id);

                    return new CustomerResult(model);
                }
                catch (Exception e)
                {

                    return null;
                }
            }
            else
            {
                return null;
            }


        }

        public async Task<IList<Customer>> Find(string role)
        {
            string authorization = "Read";
            var validation = await this.profileAuthRepository.Verification(role, authorization);

            if (validation == true)
            {
                try
                {
                    var model = await this.customerRepository.FindAsync();

                    return model;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<CustomerResult> StatusUpdate(Guid id, StatusType statusType)
        {
            try
            {
                var model = await this.customerRepository.GetAsync(id);

                if (this.HasErrors())
                    return null;

                await this.customerRepository.StatusUpdateAsync(id, statusType);


                return new CustomerResult(model);
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
