using Microsoft.Owin;
using Owin;
using System;
using Microsoft.Owin.Security.Cookies;

using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using testMvcProject.DataBase;
using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;
using testMvcProject.DataBaseDAOs.Resources.Furniture;
using testMvcProject.DataBaseDAOs.Resources.Profile;
using testMvcProject.DataBaseDAOs.Balance;

[assembly: OwinStartup(typeof(IdentityUoWApp.Startup))]
namespace IdentityUoWApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new Microsoft.Owin.PathString("/Account/Login"),
            });
        }
    }
}
