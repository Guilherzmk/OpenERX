using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenERX.Core.Users;

namespace OpenERX.Api.Controllers
{
    [Route("v1/sign-up")]
    public class SignUpController : ControllerBase
    {
        private readonly IUserService userService;
        
        public SignUpController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserParams userParams)
        {
            var user = await userService.CreateAsync(userParams);

            if (user == null)
                return BadRequest();


            return Ok(user);
        }

    }
}
