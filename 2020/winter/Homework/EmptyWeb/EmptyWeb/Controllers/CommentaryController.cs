using System;
using System.Linq;
using System.Threading.Tasks;
using EmptyWeb.Models;
using Microsoft.AspNetCore.Http;

namespace EmptyWeb
{
    public class CommentaryController
    {
        private Storage<Commentary> storage;

        public CommentaryController(Storage<Commentary> storage)
        {
            this.storage = storage;
        }

        public async Task SaveCommentary(HttpContext context)
        {
            var query = context.Request.Query;
            if (query.Keys.Contains("blogGuid"))
            {
                var commentary = new Commentary();
                commentary.Guid = Guid.NewGuid().ToString();
                commentary.Text = context.Request.Form["text"];
                commentary.DateTime = DateTime.Now;
                commentary.UserName = context.Request.Form["name"];
                commentary.RelatedPost = query["blogGuid"];
                storage.Save(commentary);
                await context.Response.WriteAsync("Entry added successful");
            }
        }

        public async Task DeleteCommentary(HttpContext context)
        {
            var query = context.Request.Query;
            if (query.Keys.Contains("commentaryGuid"))
            {
                var commentaryGuid = query["commentaryGuid"];
                storage.Delete(storage.Items.FirstOrDefault(x => x.Guid == commentaryGuid));
                await context.Response.WriteAsync("Entry was deleted");
            }
        }
    }
}