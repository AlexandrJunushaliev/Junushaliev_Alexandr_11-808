using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialNetwork.Models;

namespace SocialNetwork.Filters
{
    public class AdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.ContainsKey("Role") || context.HttpContext.Request.Cookies["Role"] != "Admin")
                context.Result = new RedirectToActionResult("Index", "Home", null);
            base.OnActionExecuting(context);
        }
    }
}