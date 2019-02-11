using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebAPITokenAutentication
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identify = new ClaimsIdentity(context.Options.AuthenticationType);

            if (context.UserName == "admin" && context.Password == "admin")
            {
                identify.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                identify.AddClaim(new Claim("username", "admin"));
                identify.AddClaim(new Claim(ClaimTypes.Name, "JORGE SILVA ZUNIGA"));
                context.Validated(identify);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identify.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identify.AddClaim(new Claim("username", "user"));
                identify.AddClaim(new Claim(ClaimTypes.Name, "CAMILLE GADEL"));
                context.Validated(identify);
            }
            else
            {
                context.SetError("Invalid_grant", "username and password is incorrect");
                return;
            }
        }


        //public override Task ValidateClientAutorization(OAuthValidateClientAuthenticationContext context)
        //{
        //    context.Validated();
        //}




        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        //{
        //    var identify = new ClaimsIdentity(context.Options.AuthenticationType);

        //    if(context.UserName == "admin" && context.Password == "admin")
        //    {
        //        identify.AddClaim(new Claim(ClaimTypes.Role, "admin"));
        //        identify.AddClaim(new Claim("username", "admin"));
        //        identify.AddClaim(new Claim(ClaimTypes.Name, "JORGE SILVA ZUNIGA"));
        //        context.Validated(identify);
        //    }else if (context.UserName == "user" && context.Password == "user")
        //    {
        //        identify.AddClaim(new Claim(ClaimTypes.Role, "user"));
        //        identify.AddClaim(new Claim("username", "user"));
        //        identify.AddClaim(new Claim(ClaimTypes.Name, "CAMILLE GADEL"));
        //        context.Validated(identify);
        //    }
        //    else
        //    {
        //        context.SetError("Invalid_grant", "username and password is incorrect");
        //        return;
        //    }
        //}


    }
}