using Microsoft.AspNetCore.Authorization;

namespace SocialNetwork.Policy
{
    public class TimeAccessRequirement : IAuthorizationRequirement
    {
        public int Time = 15;
    }
}