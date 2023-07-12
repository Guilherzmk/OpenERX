using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenERX.Core.SignIns;
using OpenERX.Core.Users;

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

            if (_signInService.HasErrors() || result is null)
            {
                var y = await Task.FromResult(Unauthorized(
                new
                {
                    Code = 1,
                    Text = "err"
                }));

                return y;
            }
            var x = await Task.FromResult(this.Ok(result));


            return x;
        }
    }
}
