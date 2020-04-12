using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Models
{
    public class User
    {
        [Key]
        public string Username { get; set; }
        //no hash, no salt
        public string Password { get; set; }
    }
}