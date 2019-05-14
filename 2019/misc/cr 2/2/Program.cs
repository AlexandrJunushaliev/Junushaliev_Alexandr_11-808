using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft;
using Newtonsoft.Json;

namespace ConsoleApp43
{
    class Comment
    {
        public int PostId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var url = string.Format("https://jsonplaceholder.typicode.com/comments");
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Task<string> answer = null;
            using (Stream s = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(s))
                {
                    answer = reader.ReadToEndAsync();
                }
            }
            var a = answer.Result;
            var comments = JsonConvert.DeserializeObject<Comment[]>(a);
            var needComments = comments.Where(v => v.Id % 2 == 0);
            Count(needComments);
            
        }
        static void Count(IEnumerable<Comment> needComments)
        {
            foreach (var comment in needComments)
            {
                Console.WriteLine(comment.Body.Length);
            }
        }
    }
}
