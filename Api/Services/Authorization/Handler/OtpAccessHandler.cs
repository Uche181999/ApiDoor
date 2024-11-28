using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Api.Services.Authorization.Requirement;
using Microsoft.AspNetCore.Authorization;

namespace Api.Services.Authorization.Handler
{
    public class OtpAccessHandler: AuthorizationHandler<OtpAccessRequirement,Otp>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OtpAccessRequirement requirement, Otp resource)
        {
            var user = context.User;
            var userOrg = user.FindFirst("OrganisationId")?.Value!;
            var orgId = resource.OrganizationId;

            if ( userOrg != null)
            {
                var stringOrgId = orgId.ToString();
                if (stringOrgId == userOrg)
                {
                    context.Succeed(requirement);
                }

            }

            return Task.CompletedTask;


        } 
    }
}