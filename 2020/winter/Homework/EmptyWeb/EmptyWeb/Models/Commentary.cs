using System;

namespace EmptyWeb.Models
{
    public class Commentary
    {
        public string RelatedPost { get; set; }
        public string Guid { get; set; }
        [NotEmpty] public string UserName { get; set; }

        [NotEmpty] public string Text { get; set; }

        public DateTime DateTime { get; set; }
    }
}