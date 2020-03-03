using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace EmptyWeb
{
    public class HomeController
    {
        public async Task GetForm(HttpContext context)
        {
            await context.Response.WriteAsync(File.ReadAllText("Views\\index.html"));
        }

        public async Task DeletePost(HttpContext context)
        {
            var query = context.Request.Query;
            if (query.Keys.Contains("postName"))
            {
                var file = new FileInfo(query["postName"]);
                file.Delete();
            }

            await context.Response.WriteAsync("Entry was deleted");
        }

        public async Task FileProvider(HttpContext context)
        {
            //странно, но файлы почему-то не достает, пришлось endpoint написать свой, не знаю, в чем дело
            await context.Response.SendFileAsync(context.Request.Path.Value.Substring(1));
        }

        public async Task OpenPost(HttpContext context)
        {
            var resPageSb = new StringBuilder();
            var query = context.Request.Query;
            if (query.Keys.Contains("postName"))
            {
                resPageSb.Append(
                    $"<!DOCTYPE html><html><head><meta charset=\"utf-8\"/<title></title></head><body><form action=\"/posts/rewritePost?postName={query["postName"]}\" method=\"post\" enctype=\"multipart/form-data\">");
                using (StreamReader sr = new StreamReader(query["postName"]))
                {
                    var text = await sr.ReadToEndAsync();
                    var postContent = text.Split(';');
                    resPageSb.Append(
                        $"Наименование: <input name=\"name\" value = {postContent[0]}/> <br/> Время: {postContent[1]} <br/> Текст: <textarea name=\"text\">{postContent[2]}</textarea> <br/> Изображение: <img src = \\{postContent[3]}/> <br/> Заменить изображение? <br/>  <input name=\"image\" type=\"file\" accept=\"image/*\"/> <br/> <input value=\"Сохранить изменения\" type=\"submit\"/>");
                }

                resPageSb.Append("</form></body></html>");
            }


            await context.Response.WriteAsync(resPageSb.ToString());
        }

        public async Task GetPosts(HttpContext context)
        {
            var filePath = "Files";
            var resPageSb =
                new StringBuilder("<!DOCTYPE html><html><head><meta charset=\"utf-8\"/<title></title></head><body>");
            var posts = Directory.GetFiles(filePath, "*.csv", SearchOption.AllDirectories);
            foreach (var post in posts)
            {
                resPageSb.Append(
                    $"{post} <a href=\"Posts/DeletePost?postName={post}\">Удалить пост</a> <a href=\"Posts/OpenPost?postName={post}\">Открыть пост</a> <br/>");
            }

            resPageSb.Append("</body></html>");

            await context.Response.WriteAsync(resPageSb.ToString());
        }

        public async Task RewritePost(HttpContext context)
        {
            var query = context.Request.Query;
            if (query.Keys.Contains("postName"))
            {
                string filePath = "Files";
                foreach (var formFile in context.Request.Form.Files)
                {
                    if (formFile.Length <= 0) continue;
                    string newFile = Path.Combine(filePath, formFile.FileName);
                    //вообще, скорее всего, тут надо делать проверки на наличие такого файла на диске по хешкоду,
                    //но я не знаю, как это правильно делается
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

                var lockObj = new object();
                lock (lockObj)
                {
                    string name = context.Request.Form["name"];
                    string text = context.Request.Form["text"];
                    var curTime = DateTime.Now;
                    string csvFileName = Path.Combine($"{query["postName"]}");
                    var filePathsSb = new StringBuilder();
                    foreach (var formFile in context.Request.Form.Files)
                    {
                        filePathsSb.Append($"{Path.Combine(filePath, formFile.FileName)},{Environment.NewLine}");
                    }

                    filePathsSb.Remove(filePathsSb.Length - 3, 3);

                    var fileContent = $"\"{name}\";{curTime};\"{text}\";{filePathsSb}";
                    File.WriteAllLines(csvFileName, new[] {fileContent});
                }
            }


            await context.Response.WriteAsync("Entry was changed");
        }

        public async Task AddEntry(HttpContext context)
        {
            //а вообще не будет ли того, что контекст подменится при асинхронном доступе?
            //тогда по сути весь метод надо в локе делать?
            string filePath = "Files";
            foreach (var formFile in context.Request.Form.Files)
            {
                if (formFile.Length <= 0) continue;
                string newFile = Path.Combine(filePath, formFile.FileName);
                //вообще, скорее всего, тут надо делать проверки на наличие такого файла на диске по хешкоду,
                //но я не знаю, как это правильно делается
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

            var lockObj = new object();
            lock (lockObj)
            {
                string name = context.Request.Form["name"];
                string text = context.Request.Form["text"];
                var curTime = DateTime.Now;
                string csvFileName = Path.Combine(filePath,
                    $"{Guid.NewGuid()}.csv");
                var filePathsSb = new StringBuilder();
                foreach (var formFile in context.Request.Form.Files)
                {
                    filePathsSb.Append($"{Path.Combine(filePath, formFile.FileName)},{Environment.NewLine}");
                }

                filePathsSb.Remove(filePathsSb.Length - 3, 3);

                var fileContent = $"\"{name}\";{curTime};\"{text}\";{filePathsSb}";
                File.AppendAllLines(csvFileName, new[] {fileContent});
            }

            await context.Response.WriteAsync("New Entry was added");
        }
    }
}