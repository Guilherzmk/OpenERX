using Microsoft.Extensions.DependencyInjection;
using OpenERX.Core.Customers;
using OpenERX.Core.Profiles;
using OpenERX.Core.SignIns;
using OpenERX.Core.Users;
using OpenERX.Repositories.Customers;
using OpenERX.Repositories.Shared.Entities.Addresses;
using OpenERX.Repositories.Shared.Entities.Emails;
using OpenERX.Repositories.Shared.Entities.Fields;
using OpenERX.Repositories.Shared.Entities.Phones;
using OpenERX.Repositories.Shared.Entities.Profiles;
using OpenERX.Repositories.Shared.Entities.Profiles.ProfileAuths;
using OpenERX.Repositories.Shared.Entities.Sites;
using OpenERX.Repositories.Shared.Sql;
using OpenERX.Repositories.SignIns;
using OpenERX.Repositories.Users;
using OpenERX.Services.Credentials;
using OpenERX.Services.Customers;
using OpenERX.Services.Profiles;
using OpenERX.Services.SignIns;
using OpenERX.Services.Users;
using OpenERX.WebAPI.Credentials;

namespace OpenERX.Test
{
    [TestClass]
    public class Dependency
    {
        public ICustomerService customerService;
        public IProfileService profileService;
        public ICredentialService credentialService;

        [TestInitialize]
        public void Init()
        {
            var services = new ServiceCollection();
<<<<<<< HEAD
            services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=DESKTOP-UJHJIPK\\SQLEXPRESS;database=db_openerx;user=sa;password=123456"));
=======
            services.AddTransient<SqlConnectionProvider>(_ => new SqlConnectionProvider("server=.;database=db_openerx;user=sa;password=123456"));
>>>>>>> eca93b874836508340f76bb5eac81074136389b0

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IEmailRepository, EmailRepository>();
            services.AddTransient<IPhoneRepository, PhoneRepository>();
            services.AddTransient<ISiteRepository, SiteRepository>();
            services.AddTransient<IFieldsRepository, FieldsRepository>();
            services.AddTransient<IProfileAuthRepository, ProfileAuthRepository>();
            services.AddTransient<IProfileRepository, ProfileRepository>();
            services.AddTransient<ISignInRepository, SignInRepository>();

            services.AddTransient<ISignInService, SignInService>();
            services.AddTransient<ICredentialService, CredentialService>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProfileService, ProfileService>();

            var provider = services.BuildServiceProvider();
            this.customerService = provider.GetService<ICustomerService>();
            this.profileService = provider.GetService<IProfileService>();
            
            

        }
    }
}
