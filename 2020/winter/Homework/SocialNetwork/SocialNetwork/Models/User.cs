using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace SocialNetwork.Models
{
    public class User:IdentityUser
    {
        public string Role { get; set; }
        public List<Commentary> Commentaries { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}