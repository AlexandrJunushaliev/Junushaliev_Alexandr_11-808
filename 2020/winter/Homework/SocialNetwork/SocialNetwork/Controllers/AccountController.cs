﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            User user = new User
                {Email = model.Email, UserName = model.Email, Role = model.Email == "admin@mail.ru" ? "Admin" : "User"};
            HttpContext.Response.Cookies.Append("Role", model.Email == "admin@mail.ru" ? "Admin" : "User");
            // добавляем пользователя
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel {ReturnUrl = returnUrl});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var result =
                await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                HttpContext.Response.Cookies.Append("Role", model.Email == "admin@mail.ru" ? "Admin" : "User");    
                // проверяем, принадлежит ли URL приложению
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Неправильный логин и (или) пароль");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Response.Cookies.Delete("Role");
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}