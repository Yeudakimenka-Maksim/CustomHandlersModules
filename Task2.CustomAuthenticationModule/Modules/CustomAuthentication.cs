using System.Security.Principal;
using System.Web;

namespace Task2.CustomAuthenticationModule.Modules
{
    public static class CustomAuthentication
    {
        public static void SetCookies(string username)
        {
            HttpContext.Current.Response.Cookies.Add(new HttpCookie("username", username));
        }

        public static IPrincipal GetCurrentUser()
        {
            var username = HttpContext.Current.Request.Cookies["username"];
            return username != null ? new GenericPrincipal(new GenericIdentity(username.Value), null) : null;
        }
    }
}