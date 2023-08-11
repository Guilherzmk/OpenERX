using OpenERX.Commons.Credentials;
using OpenERX.Commons.Results;
using OpenERX.Core.Profiles;
using OpenERX.Repositories.Shared.Entities.Profiles;
using OpenERX.Repositories.Shared.Entities.Profiles.ProfileAuths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Services.Profiles
{
    public class ProfileService : ResultService, IProfileService
    {
        private readonly IProfileRepository profileRepository;
        private readonly IProfileAuthRepository profileAuthRepository;

        public ProfileService(
            IProfileRepository profileRepository,
            IProfileAuthRepository profileAuthRepository)
        {
            this.profileRepository = profileRepository;
            this.profileAuthRepository = profileAuthRepository;
        }


        public async Task<Profile> CreateAsync(ProfileParams createParams, Guid role)
        {
            Guid authorization = Guid.Parse("A63A50AB-50C5-48A8-BA5B-560654A4F9F7"); //Create
           

            if(  true)
            {
                var credential = new Credential();

                try
                {
                    var model = await Profile.CreateAsync(
                        createParams,
                        credential,
                        this);

                    var result = await this.profileRepository.InsertProfileAsync(model);

                    return model;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public async Task<IList<Profile>> Find(Guid profileId)
        {
            Guid authorization = Guid.Parse("F776C6C5-9294-443E-AF1A-82ABA4C3BBD6"); //Read
            var validation = await this.profileAuthRepository.Verification(profileId, authorization);

            if (validation == true)
            {
                try
                {
                    var model = await this.profileRepository.Find();

                    return model;
                }
                catch (Exception e)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }




        }

        public Task<Profile> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
