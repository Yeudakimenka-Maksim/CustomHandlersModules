using System;
using System.Web;

namespace Task2.CustomAuthenticationModule.Handlers
{
    public class Logoff : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Cookies["user"] != null)
                context.Response.Cookies["user"].Expires = DateTime.Now.AddMinutes(-30);
            context.Response.Write("logged off");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}