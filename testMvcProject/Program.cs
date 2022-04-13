using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using testMvcProject.Models;
using testMvcProject.Models.Resources.ImplementedResources;

namespace testMvcProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
            Furniture furniture = new Furniture("deshman", 1500, 2500);
            Profile profile = new Profile("deshman", 400, 900);
            Window window = new Window(100, 100, furniture, profile, 2, true);
            Console.Out.WriteLine(window.getPerimeter() + " - perimeter");
            Console.Out.WriteLine(window.calculate() + " - calculatingSumm");
            */
            

            CreateHostBuilder(args).Build().Run();





        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });


    }
}
