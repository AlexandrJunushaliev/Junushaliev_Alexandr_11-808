using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class CommentariesController : Controller
    {
        private ApplicationContext _context;
        private const string pathToBlogs = "/Blogs";
        private const string pathToHome = "/";

        public CommentariesController(DbContext dbContext)
        {
            _context = (ApplicationContext) dbContext;
        }

        public IActionResult CreateCommentary(int blogId)
        {
            var model = new CommentaryViewModel() {BlogId = blogId};
            return View(model);
        }

        [HttpPost]
        public IActionResult CreateCommentary(CommentaryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var relatedBlog = _context.Blogs.FirstOrDefault(x => x.Id == model.BlogId);
            if (relatedBlog == null)
            {
                return Redirect(pathToHome);
            }

            var commentary = new Commentary()
            {
                Text = model.Text, UserName = model.Username, Blog = relatedBlog, BlogId = model.BlogId,
                DateTime = DateTime.Now
            };
            _context.Commentaries.Add(commentary);
            _context.SaveChanges();
            return Redirect(pathToBlogs);
        }

        public IActionResult UpdateCommentary(int commentaryId)
        {
            var commentary = _context.Commentaries.FirstOrDefault(x => x.Id == commentaryId);
            if (commentary == null)
            {
                return Redirect(pathToHome);
            }

            var model = new CommentaryViewModel()
                {BlogId = commentary.BlogId, Username = commentary.UserName, Text = commentary.Text};
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateCommentary(CommentaryViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var commentary = _context.Commentaries.FirstOrDefault(x => x.Id == model.CommentaryId);
            if (commentary == null)
            {
                return Redirect(pathToHome);
            }

            commentary.Text = model.Text;
            commentary.UserName = model.Username;
            _context.SaveChanges();
            return Redirect(pathToBlogs);
        }

        public IActionResult DeleteCommentary(int commentaryId)
        {
            var commentary = _context.Commentaries.FirstOrDefault(x => x.Id == commentaryId);
            if (commentary == null)
            {
                return Redirect(pathToBlogs);
            }

            _context.Commentaries.Remove(commentary);
            _context.SaveChanges();
            return Redirect(pathToBlogs);
        }
    }
}