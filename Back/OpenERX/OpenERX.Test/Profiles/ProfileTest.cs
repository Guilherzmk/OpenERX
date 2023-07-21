using OpenERX.Core.Profiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Test.Profiles
{
    [TestClass]
    public class ProfileTest : Dependency
    {
        [TestMethod]
        public async Task CreateProfileAsync()
        {
            var profile = new ProfileParams
            {
                Name = "Admin",
                Note = "Administrador"
            };

            var result = await profileService.CreateAsync(profile, Guid.Parse("76BB72BB-16CA-4339-8204-C21C828AF779"));

            if (profileService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in profileService.Errors)
                {
                    sb.AppendLine(error.Text);
                }

                throw new Exception(sb.ToString());
            }
        }

        [TestMethod]
        public async Task FindProfileAsync()
        {
            var result = await profileService.Find(Guid.Parse("F776C6C5-9294-443E-AF1A-82ABA4C3BBD6"));

            if (profileService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in profileService.Errors)
                {
                    sb.AppendLine(error.Text);
                }

                throw new Exception(sb.ToString());
            }
        }
    }
}
