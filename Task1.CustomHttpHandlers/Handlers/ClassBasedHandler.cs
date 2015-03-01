using System.IO;
using System.Net;
using System.Web;

namespace Task1.CustomHttpHandlers.Handlers
{
    public class ClassBasedHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            try
            {
                context.Response.WriteFile("~/contact.json");
            }
            catch (IOException)
            {
                context.Response.StatusCode = (int) HttpStatusCode.NotFound;
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}