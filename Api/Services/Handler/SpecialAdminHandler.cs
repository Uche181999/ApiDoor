using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Authorization
{
    public class SpecialAdminHandler : AuthorizationHandler<SpecialAdminRequirement>
    {
        private readonly UserManager<AppUser> _userManager;
        public SpecialAdminHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;

        }

        protected async  override Task<Task> HandleRequirementAsync(AuthorizationHandlerContext context, SpecialAdminRequirement requirement)
        {
            var User = context.User;
            var userOrg = int.Parse(User.FindFirst("OrganisationId")?.Value!);
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            var targetUserName = context.Resource as string;
            var targetUser =await  _userManager.Users.FirstOrDefaultAsync(c => c.UserName == targetUserName);
            var targetOrg = targetUser?.OrganisationId ;

            if (userRole == "admin" && (userOrg == 1 || userOrg == targetOrg))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
