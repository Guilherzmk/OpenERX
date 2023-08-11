using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenERX.Core.SignIns;
using OpenERX.Core.Users;
using OpenERX.Services.Customers;
using System.Text;

namespace OpenERX.Api.Controllers
{
    [Route("v1/sign-in")]
    public class SignInController : Controller
    {
        private readonly ISignInService _signInService;

        public SignInController(ISignInService signInService)
        {
            _signInService = signInService;
        }
 
        [HttpPost("")]
        [AllowAnonymous]
        public async Task<IActionResult> SignInAsync([FromBody] SignInParams @params)
        {
            var result = await _signInService.SignInAsync(@params);

            if (_signInService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in _signInService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest("erro");
                throw new Exception(sb.ToString());
            }

            var obj = new
            {
                token = result.Token
            };

            return this.Ok(result);
        }
    }
}
