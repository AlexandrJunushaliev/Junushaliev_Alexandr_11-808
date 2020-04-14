using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Models
{
    public class ApplicationContext:IdentityDbContext<User>
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }    
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}