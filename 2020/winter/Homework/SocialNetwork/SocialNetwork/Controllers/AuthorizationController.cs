using System;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class AuthorizationController : Controller
    {
        private ApplicationContext _context;

        public AuthorizationController(DbContext dbContext)
        {
            _context = (ApplicationContext) dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SingUpViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var user = new User() {Username = model.UserName, Password = model.Password};
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                var cookie = new CookieOptions {Expires = new DateTimeOffset(DateTime.Now + TimeSpan.FromHours(2))};
                //no jwt
                HttpContext.Response.Cookies.Append("AuthToken",JsonConvert.SerializeObject(user), cookie);
                return Redirect("/");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult LogIn()
        {
            var cookie = new CookieOptions {Expires = new DateTimeOffset(DateTime.Now + TimeSpan.FromHours(2))};
            HttpContext.Response.Cookies.Append("loggedIn", "yes", cookie);
            return RedirectToAction("Index");
        }
    }
}