using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SocialNetwork.Models
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Commentary> Commentaries { get; set; }     
        public DbSet<User> Users { get; set; }
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=socialNetworkDb1;Username=postgres;Password=password");
        }
    }
}