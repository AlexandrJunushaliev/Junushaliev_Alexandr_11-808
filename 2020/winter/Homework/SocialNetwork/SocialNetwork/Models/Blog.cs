using System;
using System.Collections.Generic;

namespace SocialNetwork.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
        public DateTime DateTime { get; set; }
        public List<Commentary> Commentaries { get; set; }
        public User User { get; set; }
    }
}