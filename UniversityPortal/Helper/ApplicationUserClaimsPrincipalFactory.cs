using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using UniversityPortal.Models;

namespace UniversityPortal.Helper
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser,IdentityRole>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IOptions<IdentityOptions> _options;

        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,IOptions<IdentityOptions> options)
            :base(userManager,roleManager,options)
        {
            _userManager = userManager;
            _roleManager = roleManager;
           _options = options;
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);

            identity.AddClaim(new Claim("UserFirstName", user.FirstName ?? ""));
            identity.AddClaim(new Claim("UserLastName", user.LastName ?? ""));
            identity.AddClaim(new Claim("UserName", user.UserName ?? ""));

            /*identity.AddClaim(claim: new Claim(){ user = user.UserId });*/

            return identity;
        }
    }
}
