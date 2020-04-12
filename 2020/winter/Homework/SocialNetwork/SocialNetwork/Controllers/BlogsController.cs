using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialNetwork.Authorization;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationContext _context;

        public BlogsController(DbContext dbContext)
        {
            _context = (ApplicationContext) dbContext;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blogs.Include(x => x.Commentaries).ToList();
            return View(blogs);
        }

        [AuthorizationRequired]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var blog = new Blog() {Text = model.Text, BlogName = model.BlogName, DateTime = DateTime.Now};
            _context.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UpdateBlog(int blogId)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == blogId);
            if (blog == null)
            {
                return RedirectToAction("Index");
            }

            var model = new BlogViewModel() {Id = blogId, BlogName = blog.BlogName, Text = blog.Text};
            return View(model);
        }

        [HttpPost]
        public IActionResult UpdateBlog(BlogViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == model.Id);
            if (blog == null)
            {
                return RedirectToAction("Index");
            }

            blog.Text = model.Text;
            blog.BlogName = model.BlogName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBlog(int blogId)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == blogId);
            if (blog  == null)
            {
                return RedirectToAction("Index");
            }

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}