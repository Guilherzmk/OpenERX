﻿using Microsoft.AspNetCore.CookiePolicy;
using OpenERX.Commons.Credentials;
using OpenERX.Core.Users;
using OpenERX.Repositories.Users;
using OpenERX.WebAPI.Credentials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OpenERX.Services.Credentials
{
    public class CredentialService : ICredentialService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserRepository userRepository;
        private static string userId = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/hash";
        

        public CredentialService(IHttpContextAccessor httpContextAccessor,
            IUserRepository userRepository) 
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userRepository = userRepository;
        }


        public async Task<User> GetContextUser()
        { 
            foreach (Claim claims in httpContextAccessor.HttpContext.User.Claims)
            {
                if (claims.Type == userId)
                {
                    var id = claims.Value;
                    
                    var user = await userRepository.Get(Guid.Parse(id));

                    return user;
                }
            }
            return null;
        }

        public async Task<Credential> CreateCredential()
        {
            var credential = new Credential();

            var user = await GetContextUser();

            credential.UserId = user.Id;
            credential.UserName = user.Name;
            credential.ProfileCode = user.ProfileId;
            credential.BrokerName = "Guilherme";
            credential.AccessKey = user.AccessKey;
            credential.ApiKey = user.Token;

            return credential;
        }

        public async Task<Guid> GetContextProfile()
        {
            var user = new User();

            user = await GetContextUser();

            var profile = user.ProfileId;

            return profile;
        }

    }
}
