using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SocialNetwork.Filters;
using SocialNetwork.Models;

namespace SocialNetwork.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationContext _context;
        private readonly UserManager<User> _userManager;

        public BlogsController(ApplicationContext dbContext, UserManager<User> userManager)
        {
            _userManager = userManager;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            var blogs = _context.Blogs.Include(x => x.Commentaries).ThenInclude(x => x.User).Include(x=>x.User).ToList();
            return View(blogs);
        }

        [Authorize]
        public IActionResult CreateBlog()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(BlogViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var blog = new Blog()
            {
                Text = model.Text, BlogName = model.BlogName, DateTime = DateTime.Now,
                User = await _userManager.GetUserAsync(User)
            };
            _context.Add(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult UpdateBlog(int blogId)
        {
            var blog = _context.Blogs.Include(x => x.User).FirstOrDefault(x => x.Id == blogId);
            if (blog == null || User.Identity.Name != blog.User.UserName)
            {
                return RedirectToAction("Index");
            }

            var model = new BlogViewModel() {Id = blogId, BlogName = blog.BlogName, Text = blog.Text};
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult UpdateBlog(BlogViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var blog = _context.Blogs.Include(x => x.User).FirstOrDefault(x => x.Id == model.Id);
            if (blog == null || User.Identity.Name != blog.User.UserName)
            {
                return RedirectToAction("Index");
            }

            blog.Text = model.Text;
            blog.BlogName = model.BlogName;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Admin]
        public IActionResult DeleteBlog(int blogId)
        {
            var blog = _context.Blogs.FirstOrDefault(x => x.Id == blogId);
            if (blog == null)
            {
                return RedirectToAction("Index");
            }

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}