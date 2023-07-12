using OpenERX.Commons.Results;
using OpenERX.Commons.Types.Results;
using OpenERX.Core.Customers;
using OpenERX.Core.Users;
using OpenERX.Repositories.Criptographys;
using OpenERX.Repositories.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Services.Users
{
    public class UserService : ResultService, IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(
            IUserRepository userRepository
        )
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> CreateAsync(UserParams createParams)
        {
            try
            {
             var model = await User.Create(createParams);

                if (this.HasErrors())
                    return null;

                var user = await this.userRepository.InsertAsync(model);

                if (user == null)
                {
                    return null;
                }

                return new UserResult(model);

            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<UserResult> LoginAsync(string accessKey, string password)
        {
            try
            {
                var user = await this.userRepository.Get(accessKey);

                var encode = Cryptography.CreateHash(password);
                string passwordEncoded = Convert.ToBase64String(encode);

                if (user.Password == passwordEncoded)
                {
                    return new UserResult(user);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }



    }
}
