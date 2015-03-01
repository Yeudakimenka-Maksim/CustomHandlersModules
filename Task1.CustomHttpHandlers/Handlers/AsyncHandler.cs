using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace Task1.CustomHttpHandlers.Handlers
{
    public class AsyncHandler : HttpTaskAsyncHandler
    {
        public override bool IsReusable
        {
            get { return false; }
        }

        public override async Task ProcessRequestAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                var content = await GetFileContent(context.Server.MapPath("~/contact.json"));
                context.Response.Write(content);
            }
            catch (IOException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            }
        }

        private static Task<string> GetFileContent(string path)
        {
            return Task.FromResult(File.ReadAllText(path));
        }
    }
}