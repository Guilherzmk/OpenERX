﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenERX.Commons.Params;
using OpenERX.Commons.Types.Results;
using OpenERX.Core.Customers;
using OpenERX.Core.Users;
using OpenERX.WebAPI.Credentials;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace OpenERX.Api.Controllers
{
    [Route("v1/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICredentialService credentialService;
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService,
            ICredentialService credentialService)
        {
            this.customerService = customerService;
            this.credentialService = credentialService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerParams createParams)
        {

            var id = await credentialService.GetContextProfile();
            var credential = await credentialService.CreateCredential();

            var customer = await customerService.CreateAsync(createParams, id, credential);

            if (customerService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in customerService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest("erro");
                throw new Exception(sb.ToString());
            }

            return this.Ok(customer);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] CustomerParams updateParams)
        {
            var userId = await credentialService.GetContextProfile();
            var credential = await credentialService.CreateCredential();
            var customer = await customerService.UpdateAsync(id, updateParams, userId, credential);

            if (customerService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in customerService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest();
                throw new Exception(sb.ToString());
            }

            return this.Ok(customer);


        }

        [HttpDelete]
        [Route("")]
        public async Task<IActionResult> DeleteAsync([FromQuery] IdParams deleteParams)
        {

            var userId = await credentialService.GetContextProfile();
            var customer = await customerService.DeleteAsync(deleteParams, userId);

            if (customerService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in customerService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest();
                throw new Exception(sb.ToString());
            }

            return this.Ok();

        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAsync([FromRoute] Guid id)
        {
            var userId = await credentialService.GetContextProfile();
            var customer = await customerService.GetAsync(id, userId);

            if (customerService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in customerService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest();
                throw new Exception(sb.ToString());
            }

            return this.Ok(customer);

        }

        [HttpGet]
        [Route("")]

      
        public async Task<IActionResult> Find()
        {
            var id = await credentialService.GetContextProfile();
            var customers = await customerService.Find(id);

            if (customerService.HasErrors())
            {
                var sb = new StringBuilder();
                foreach (var error in customerService.Errors)
                {
                    sb.AppendLine(error.Text);
                }
                return BadRequest();
                throw new Exception(sb.ToString());
            }

            return this.Ok(customers);

        }

    }
}
