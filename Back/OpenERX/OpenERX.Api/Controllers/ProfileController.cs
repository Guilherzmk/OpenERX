using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenERX.Core.Profiles;
using OpenERX.Services.Customers;
using OpenERX.WebAPI.Credentials;
using System.Text;

namespace OpenERX.Api.Controllers
{
    [Route("v1/profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly ICredentialService credentialService;
        private readonly IProfileService profileService;

        public ProfileController(
            ICredentialService credentialService,
            IProfileService profileService)
        {
            this.credentialService = credentialService;
            this.profileService = profileService;
        }

        [HttpGet]
        [Route("")]
         
        public async Task<IActionResult> Find()
        {
            var id = await credentialService.GetContextProfile();
            var profiles = await profileService.Find(id);

            if (profileService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in profileService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest();
                throw new Exception(sb.ToString());
            }

            return this.Ok(profiles);

        }


    }
}
