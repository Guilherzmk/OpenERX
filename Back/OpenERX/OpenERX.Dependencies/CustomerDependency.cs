using Microsoft.Extensions.DependencyInjection;
using OpenERX.Core.Customers;
using OpenERX.Repositories.Customers;
using OpenERX.Services.Customers;

namespace OpenERX.Dependencies
{
    public static class CustomerDependency
    {
        public static void AddCustomerDependencies(this IServiceCollection services)
        {
            //Customers
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
        }
    }
}
