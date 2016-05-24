using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using test.DataAccess;

namespace test.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            AppUser appUser = DAFileRegistration.GetAppUsers(context.UserName, context.Password);
            if (appUser==null)
            {
                context.Rejected();
                return Task.FromResult(0);
            }

            var id = new ClaimsIdentity(context.Options.AuthenticationType);
            id.AddClaim(new Claim("subject", context.UserName));
            id.AddClaim(new Claim("role", "user"));
            context.Validated(id);
            return Task.FromResult(0);
        }
    }
}