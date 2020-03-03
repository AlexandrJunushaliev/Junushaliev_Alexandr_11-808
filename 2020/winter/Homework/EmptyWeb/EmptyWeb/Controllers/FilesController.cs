using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EmptyWeb
{
    public class FilesController
    {
        public async Task FileProvider(HttpContext context)
        {
            await context.Response.SendFileAsync(context.Request.Path.Value.Substring(1,context.Request.Path.Value.Length-2));
        }
    }
}