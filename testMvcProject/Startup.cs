﻿using System;
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

namespace testMvcProject
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            var connectString =
                "Server=localhost;Database=myMvcProject;User=SA;Password=reallyStrongPwd123;";

            services.AddDbContext<DBContext2>(param => param.UseSqlServer(connectString));


            services.AddMvc(option => option.EnableEndpointRouting = false);
            
            services.AddDistributedMemoryCache();

            services.AddScoped<IUserManager, UserDAO>();
            services.AddScoped<IUserLoginsPasswordsManager, UsersLoginsPasswordsDAO>();
            services.AddScoped<IFurnitureManager, FurnitureDAO>();
            services.AddScoped<IProfileManager, ProfileDAO>();
            services.AddScoped<IBalanceManager, DataBaseDAOs.Balance.BalanceDAO>();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: "Default",
                template: "{controller}/{action}");
            });

            app.Run(async (context) =>
            {
                if(context.Session.Keys.Contains("name"))
                    await context.Response.WriteAsync($"Hello {context.Session.GetString("name")}!");
                else
                {
                    context.Session.SetString("name", "Tom");
                    await context.Response.WriteAsync("Hello World!");
                }
            });

        }
    }
}
