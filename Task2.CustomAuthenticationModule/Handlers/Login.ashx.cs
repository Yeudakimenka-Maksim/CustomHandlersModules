using System;
using System.Linq;
using System.Web;
using Task2.CustomAuthenticationModule.EFDataContext;

namespace Task2.CustomAuthenticationModule.Handlers
{
    public class Login : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var username = context.Request.Params["username"];
            var password = context.Request.Params["password"];
            using (var db = new UsersModel())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username);
                if (user != null && user.Password == password)
                {
                    context.Response.Cookies.Add(new HttpCookie("user", username));
                    context.Response.Cookies["user"].Expires = DateTime.Now.AddMinutes(30);
                    context.Response.Write("logged in");
                }
                else
                    context.Response.Write("not logged in");
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}