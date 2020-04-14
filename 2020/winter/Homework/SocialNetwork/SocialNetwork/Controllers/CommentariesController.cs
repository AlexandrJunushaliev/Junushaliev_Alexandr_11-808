﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class CommentariesController : Controller
    {
        private ApplicationContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private const string pathToBlogs = "/Blogs";
        private const string pathToHome = "/";

        public CommentariesController(ApplicationContext dbContext, UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [Authorize]
        public IActionResult CreateCommentary(int blogId)
        {
            var model = new CommentaryViewModel() {BlogId = blogId};
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateCommentary(CommentaryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var relatedBlog = _context.Blogs.FirstOrDefault(x => x.Id == model.BlogId);
            if (relatedBlog == null)
            {
                return Redirect(pathToHome);
            }


            var commentary = new Commentary()
            {
                Text = model.Text, Blog = relatedBlog, BlogId = model.BlogId,
                DateTime = DateTime.Now, User = await _userManager.GetUserAsync(User)
            };
            _context.Commentaries.Add(commentary);
            _context.SaveChanges();
            return Redirect(pathToBlogs);
        }

        [Authorize]
        public IActionResult UpdateCommentary(int commentaryId)
        {
            var commentary = _context.Commentaries.Include(x=>x.User).FirstOrDefault(x => x.Id == commentaryId);
            if (commentary == null || User.Identity.Name != commentary.User.UserName)
            {
                return Redirect(pathToHome);
            }

            var model = new CommentaryViewModel()
                {BlogId = commentary.BlogId, Text = commentary.Text};
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateCommentary(CommentaryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var commentary = _context.Commentaries.Include(x=>x.User).FirstOrDefault(x => x.Id == model.CommentaryId);
            if (commentary == null || User.Identity.Name != commentary.User.UserName)
            {
                return Redirect(pathToHome);
            }

            commentary.Text = model.Text;
            _context.SaveChanges();
            return Redirect(pathToBlogs);
        }

        [Authorize]
        public IActionResult DeleteCommentary(int commentaryId)
        {
            var commentary = _context.Commentaries.Include(x=>x.User).FirstOrDefault(x => x.Id == commentaryId);
            if (commentary == null || User.Identity.Name != commentary.User.UserName)
            {
                return Redirect(pathToBlogs);
            }

            _context.Commentaries.Remove(commentary);
            _context.SaveChanges();
            return Redirect(pathToBlogs);
        }
    }
}