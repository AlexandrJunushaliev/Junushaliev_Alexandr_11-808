using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Controllers;

namespace SocialNetwork.Authorization
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //вообще тут можно было использовать неймспейс любого из контроллеров, но это какой-то костыль
            //это в принципе тоже, а как сделать правильно не понятно
            //а еще я не очень понимаю, как тут от хардкода избавляться
            var calledController =
                Type.GetType($"SocialNetwork.Controllers.{context.Request.RouteValues["Controller"]}Controller");
            var calledAction = calledController?.GetMember(context.Request.RouteValues["Action"].ToString())
                .FirstOrDefault();
            var authRequired = calledAction?.GetCustomAttributes(typeof(AuthorizationRequiredAttribute), false).Any();
            if (authRequired.HasValue && authRequired.Value)
            {
                if (!context.Request.Cookies.ContainsKey("AuthToken"))
                {
                    var a = context.Request.Cookies["AuthToken"];
                    context.Request.RouteValues["Controller"] = "Home";
                    context.Request.RouteValues["Action"] = "Index";
                }
            }

            await _next(context);
        }
    }
}