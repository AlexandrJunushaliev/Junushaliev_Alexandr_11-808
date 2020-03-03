using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmptyWeb.Models;

namespace EmptyWeb
{
    public class BlogCsvStorage : Storage<Blog>
    {
        private const string BlogsPath = "Blogs";

        public override void LoadAll()
        {
            var blogs = new List<Blog>();
            var posts = Directory.GetFiles(BlogsPath, "*.csv", SearchOption.AllDirectories);
            foreach (var post in posts)
            {
                using (var sr = new StreamReader(post))
                {
                    var text = sr.ReadToEnd();
                    var blog = new CsvParser(';').GetBlog(text);
                    blog.Commentaries = new CommentariesCsvStorage().Items.Where(x => x.RelatedPost == post);
                    blogs.Add(blog);
                }
            }

            Items = blogs;
        }

        public override void Save(Blog entry)
        {
            File.WriteAllLines(Path.Combine(BlogsPath, $"{entry.Guid}.csv"),
                new[]
                {
                    new CsvParser(';').MakeCsv(entry.Guid, entry.DateTime.ToString(), entry.Text, entry.FileName,
                        entry.Name)
                });
        }

        public override void Delete(Blog entry)
        {
            var file = new FileInfo($"Blogs/{entry.Guid}.csv");
            file.Delete();
        }

        public override void Update(Blog updatedEntry, Blog newEntry)
        {
            File.WriteAllLines(Path.Combine(BlogsPath, $"{updatedEntry.Guid}.csv"),
                new[]
                {
                    new CsvParser(';').MakeCsv(updatedEntry.Guid, updatedEntry.DateTime.ToString(), newEntry.Text, newEntry.FileName,
                        newEntry.Name)
                });
        }
    }
}