using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Services.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;

namespace Api.Services.Authorization.Handler
{
    public class GroupAdminHandler : AuthorizationHandler<GroupAdminRequirement,Door>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GroupAdminRequirement requirement, Door resource)
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

            return Task.CompletedTask;


        }
    }
}