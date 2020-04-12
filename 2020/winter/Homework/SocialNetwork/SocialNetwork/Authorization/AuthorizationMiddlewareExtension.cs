using Microsoft.AspNetCore.Builder;

namespace SocialNetwork.Authorization
{
    public static class AuthorizationMiddlewareExtension
    {
        public static IApplicationBuilder UseCustomAuthorization(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthorizationMiddleware>();
        }
    }
}