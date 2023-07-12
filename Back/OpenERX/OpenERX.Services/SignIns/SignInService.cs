using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using OpenERX.Commons.Results;
using OpenERX.Core.Customers;
using OpenERX.Core.SignIns;
using OpenERX.Core.Users;
using OpenERX.Repositories.Criptographys;
using OpenERX.Repositories.Users;

namespace OpenERX.Services.SignIns
{
    public class SignInService : ResultService, ISignInService
    {

        private readonly IUserRepository userRepository;

        public SignInService(
            IUserRepository userRepository
        )
        {
            this.userRepository = userRepository;
        }

        public async Task<UserResult> SignInAsync(SignInParams @params)
        {
            try
            {
                var user = await this.userRepository.Get(@params.AccessKey);

                var encode = Cryptography.CreateHash(@params.Password);
                string passwordEncoded = Convert.ToBase64String(encode);

                if (user is null)
                    return null;

                user.Token = GenerateToken(user);

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

        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDecriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Hash, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDecriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
