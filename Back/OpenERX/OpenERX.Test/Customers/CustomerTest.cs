using System.Text;
using OpenERX.Core.Customers;

namespace OpenERX.Test.Customers
{
    [TestClass]
    public class CustomerTest : Dependency
    {
        [TestMethod]
        public async Task CustomerCreateAsync()
        {
            var createParams = new CustomerParams
            {
                Name = "João da Silva",
                Nickname = "joao",
                BirthDate = "21022006",
                Identity = "98765432178",
                Note = "xpto"
            };

            //var result = await customerService.CreateAsync(createParams, Guid.Parse("76BB72BB-16CA-4339-8204-C21C828AF779"));



            if (customerService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in customerService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
 
                throw new Exception(sb.ToString());
            }
        }
 

        [TestMethod]
        public async void Update()
        {
            var customer = new CustomerParams
            {

            };

         
        }


        [TestMethod]
        public async void Get()
        {
        
        }


        [TestMethod]
        public async void List()
        {

        }

    }
}