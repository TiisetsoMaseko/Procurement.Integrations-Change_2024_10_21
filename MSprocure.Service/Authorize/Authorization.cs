using Microsoft.Extensions.Configuration;
using MSprocure.Service.Authorize.IAuthorize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSprocure.Service.Authorize
{
    public class Authorization: IAuthorization
    {
        private readonly IConfiguration _config;
        public Authorization (IConfiguration config)
        {
            _config = config;
        }

        #pragma warning disable CS8618, CS1998, CS8602 // Ignore Naming Rule Violations
        public async Task<bool> AuthorizePO(MSprocure.Service.Models.Content.Requests.OrderRequest orderRequest)
        {
            var FromCredentialDomain = _config["FromCredentialDomain"];
            var FromCredentialIdentity = _config["FromCredentialIdentity"];
            var ToCredentialDomain = _config["ToCredentialDomain"];
            var ToCredentialIdentity = _config["ToCredentialIdentity"];

            var POFromCredentialDomain = orderRequest.Header.From.Credential[0].domain;
            var POFromCredentialIdentity = orderRequest.Header.From.Credential[0].Identity.Value;
            var POToCredentialDomain = orderRequest.Header.To.Credential[0].domain;
            var POToCredentialIdentity = orderRequest.Header.To.Credential[0].Identity.Value;

            if (!(FromCredentialDomain.Equals(POFromCredentialDomain) && FromCredentialIdentity.Equals(POFromCredentialIdentity)))
            {
                return false;
            }
                    
            if (!(ToCredentialDomain.Equals(POToCredentialDomain) && ToCredentialIdentity.Equals(POToCredentialIdentity)))
            {
                return false;
            }
            return true;
        }
        #pragma warning restore CS8618, CS1998, CS8602 // Ignore Naming Rule Violations
    }
}
