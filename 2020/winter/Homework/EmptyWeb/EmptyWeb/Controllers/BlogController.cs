using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmptyWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Win32;

namespace EmptyWeb
{
    public class BlogsController
    {
        private Storage<Blog> storage;

        public BlogsController(Storage<Blog> storage)
        {
            this.storage = storage;
        }

        public async Task GetForm(HttpContext context)
        {
            await context.Response.WriteAsync(File.ReadAllText("Views\\index.html"));
        }

        public async Task DeleteBlog(HttpContext context)
        {
            var query = context.Request.Query;
            if (query.Keys.Contains("blogGuid"))
            {
                var blogGuid = query["blogGuid"];
                storage.Delete(storage.Items.FirstOrDefault(x => x.Guid == blogGuid));
                await context.Response.WriteAsync("Entry was deleted");
            }
        }

        public async Task OpenBlog(HttpContext context)
        {
            var resPageSb = new StringBuilder();
            var query = context.Request.Query;
            if (query.Keys.Contains("blogGuid"))
            {
                var blogGuid = query["blogGuid"];
                resPageSb.Append(
                    $"<!DOCTYPE html><html><head><meta charset=\"utf-8\"/<title></title></head><body><form action=\"/blogs/rewriteBlog?blogGuid={blogGuid}\" method=\"post\" enctype=\"multipart/form-data\">");
                var blog = storage.Items.FirstOrDefault(x => x.Guid == blogGuid);
                resPageSb.Append(
                    $"Наименование: <input name=\"name\" value = {blog?.Name}/> <br/> Время: {blog?.DateTime} <br/> Текст: <textarea name=\"text\">{blog?.Text}</textarea> <br/> Изображение: <img src = \\Files\\{blog?.FileName}/> <br/> Заменить изображение? <br/>  <input name=\"image\" type=\"file\" accept=\"image/*\"/> <br/> <input value=\"Сохранить изменения\" type=\"submit\"/></form>");


                foreach (var commentary in new CommentariesCsvStorage().Items.Where(x => x.RelatedPost == blogGuid))
                {
                    resPageSb.Append(
                        $"<hr/>Имя пользователя:<text>{commentary.UserName}</text><br/><text>{commentary.DateTime}</text><br/><text>{commentary.Text}</text><br/><a href =\"/commentaries/deleteCommentary?commentaryGuid={commentary.Guid}\">Удалить комментарий</a>");
                }

                resPageSb.Append(
                    $@"<hr/><form action=""/commentaries/SaveCommentary?blogGuid={blogGuid}"" method=""post"" enctype=""multipart/form-data"">
                    Ваше имя:
                    <input name=""name""/>
                    <br/>
                    Текст комментария:
                    <textarea name = ""text"" ></textarea >
                    <br/> 
                    <input value = ""Подтвердить"" type = ""submit""/>"
                    
                );


                resPageSb.Append("</body></html>");
            }


            await context.Response.WriteAsync(resPageSb.ToString());
        }

        public async Task SaveBlog(HttpContext context)
        {
            string filePath = "Files";
            foreach (var formFile in context.Request.Form.Files)
            {
                if (formFile.Length <= 0) continue;
                string newFile = Path.Combine(filePath, formFile.FileName);
                using (var inputStream = new FileStream(newFile, FileMode.Create))
                {
                    // read file to stream
                    await formFile.CopyToAsync(inputStream);
                    // stream to byte array
                    byte[] array = new byte[inputStream.Length];
                    inputStream.Seek(0, SeekOrigin.Begin);
                    inputStream.Read(array, 0, array.Length);
                }
            }

            Blog blog = new Blog();
            blog.Guid = Guid.NewGuid().ToString();
            blog.Name = context.Request.Form["name"];
            blog.Text = context.Request.Form["text"];
            blog.DateTime = DateTime.Now;
            blog.FileName = context.Request.Form.Files.FirstOrDefault()?.FileName;
            storage.Save(blog);

            await context.Response.WriteAsync("New Entry was added");
        }

        public async Task GetBlogs(HttpContext context)
        {
            var resPageSb =
                new StringBuilder("<!DOCTYPE html><html><head><meta charset=\"utf-8\"/<title></title></head><body>");
            foreach (var blog in storage.Items)
            {
                resPageSb.Append(
                    $"{blog.Name} <a href=\"DeleteBlog?blogGuid={blog.Guid}\">Удалить блог</a> <a href=\"OpenBlog?blogGuid={blog.Guid}\">Открыть блог</a> <br/>");
            }

            resPageSb.Append("</body></html>");

            await context.Response.WriteAsync(resPageSb.ToString());
        }

        public async Task RewriteBlog(HttpContext context)
        {
            var query = context.Request.Query;
            if (query.Keys.Contains("blogGuid"))
            {
                var blogGuid = query["blogGuid"];
                string filePath = "Files";
                foreach (var formFile in context.Request.Form.Files)
                {
                    if (formFile.Length <= 0) continue;
                    string newFile = Path.Combine(filePath, formFile.FileName);
                    using (var inputStream = new FileStream(newFile, FileMode.Create))
                    {
                        // read file to stream
                        await formFile.CopyToAsync(inputStream);
                        // stream to byte array
                        byte[] array = new byte[inputStream.Length];
                        inputStream.Seek(0, SeekOrigin.Begin);
                        inputStream.Read(array, 0, array.Length);
                    }
                }

                Blog blog = storage.Items.FirstOrDefault(x => x.Guid == blogGuid);
                blog.Name = context.Request.Form["name"];
                blog.Text = context.Request.Form["text"];
                blog.FileName = context.Request.Form.Files.FirstOrDefault()?.FileName ?? blog.FileName;
                storage.Update(blog, blog);

                await context.Response.WriteAsync("Entry was updated");
            }
        }
    }
}