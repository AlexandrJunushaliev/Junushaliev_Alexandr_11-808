using System;

namespace SocialNetwork.Models
{
    public class Commentary
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string UserName { get; set; }

        public string Text { get; set; }

        public DateTime DateTime { get; set; }
    }
}