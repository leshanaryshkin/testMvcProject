using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.Models.DAOs.ProductsDAO;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMvcProject.Controllers
{
    public class UserController : Controller
    {


 
 
 

        public UserController()
        {
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult AdditionalServices()
        {
            return View();
        }

        public ViewResult Calculator()
        {
            return View();
        }

        public ViewResult Orders()
        {
            WindowsDAOClass windowsList = new WindowsDAOClass();
            return View(windowsList);
        }

        


    }
}
