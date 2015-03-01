using System.Security.Principal;
using System.Web;

namespace Task2.CustomAuthenticationModule.Handlers
{
    public class CheckCookies : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var user = context.Request.Cookies["user"] != null
                ? new GenericPrincipal(new GenericIdentity(context.Request.Cookies["user"].Value), null)
                : null;
            context.Response.Write(user != null ? user.Identity.Name : "no cookies");
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}