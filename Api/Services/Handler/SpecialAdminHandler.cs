using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Authorization
{
    public class SpecialAdminHandler : AuthorizationHandler<SpecialAdminRequirement, AppUser>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, SpecialAdminRequirement requirement, AppUser resource)
        {
  var user = context.User;
            var userOrg = user.FindFirst("OrganisationId")?.Value!;
            var orgId = resource.OrganisationId;
            var isAdmin = user.IsInRole("Admin");

            if (orgId != null && userOrg != null)
            {
                var stringOrgId = orgId.ToString();
                if (isAdmin && stringOrgId == userOrg)
                {
                    context.Succeed(requirement);
                }

            }

            if (isAdmin && userOrg == "1")
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}



