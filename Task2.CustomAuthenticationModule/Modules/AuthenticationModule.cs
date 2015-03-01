using System;
using System.Web;

namespace Task2.CustomAuthenticationModule.Modules
{
    public class AuthenticationModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var context = ((HttpApplication)sender).Context;
            context.User = CustomAuthentication.GetCurrentUser();
        }
    }
}