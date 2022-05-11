using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.Models.DAOs.ProductsDAO;
using testMvcProject.Models.DAOs.ResourcesDAOs;
using testMvcProject.Models.DAOs.UsersDAO;
using testMvcProject.Models.Users;
using System.Linq;
using System.Web;




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
            return View(new resourceDAO());
        }

        public ViewResult Orders()
        {
            WindowsDAOClass windowsList = new WindowsDAOClass();
            return View(windowsList);
        }
        
        public ViewResult Authorization(string telephone)
        {
            if (telephone == "404")
                ViewBag.FalseReg = "Такой пользователь не зарегистрирован";
            else if (telephone!=null)
                ViewBag.FalseReg = $"Пользователь с номером {telephone} уже есть в базе";
             

            return View();
        }
        
        [HttpPost]
        public IActionResult Registration(string telephone, string name, 
            string cityName, string streetName, string houseNumber)
        {
            UsersDAO usersDao = new UsersDAO();
            
            if (usersDao.ContainTelephone(telephone))
            {
                return RedirectToAction("Authorization", "User", new{telephone});
            }

            string Adress = cityName + " " + streetName + " " + houseNumber;
            Person person = new Person(name, telephone, Adress);
            usersDao.AddUser(person);

            
            return RedirectToAction("SuccessRegistration", "User", new{person.Name});
        }
        
    

        public ViewResult SuccessRegistration(string name)
        {
            ViewBag.Name = $"{name}";
            return View();
        }

        

        [HttpPost]
        public IActionResult LogIn(string login, string password)
        {
            UsersDAO usersDao = new UsersDAO();
            if (!usersDao.ContainAccount(login, password))
            {
                string telephone = "404";
                return RedirectToAction("Authorization", "User", new {telephone});
            }
            else
            {
                return RedirectToAction("AboutUs", "User");
 
            }
        }
    }
}
