using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SocialNetwork.Models;

namespace SocialNetwork.Policy
{
    public class CommentAuthorizationHandler : AuthorizationHandler<TimeAccessRequirement, Commentary>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            TimeAccessRequirement requirement, Commentary resource)
        {
            if ((DateTime.Now - resource.DateTime).Minutes <= requirement.Time)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}