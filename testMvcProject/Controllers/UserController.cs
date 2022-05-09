using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.Models.DAOs.ProductsDAO;
using testMvcProject.Models.DAOs.ResourcesDAOs;
using testMvcProject.Models.DAOs.UsersDAO;
using testMvcProject.Models.Users;



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
        
        public ViewResult Authorization()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Registration(string telephone, string name, 
            string cityName, string streetName, string houseNumber)
        {
            UsersDAO usersDao = new UsersDAO();
            
            if (usersDao.ContainTelephone(telephone))
            {
                ViewBag.FalseReg = "Такой пользователь уже зарегистрирован!";
                return RedirectToAction("unSuccessRegistration", "User");
            }
            else
            {
                ViewBag.FalseReg = null;
            }

            string Adress = cityName + " " + streetName + " " + houseNumber;
            Person person = new Person(name, telephone, Adress);
            usersDao.AddUser(person);

            
            return RedirectToAction("SuccessRegistration", "User", name);
        }
        
        public ViewResult FalseRegistration(string telephone)
        {
            return View(telephone);
        }

        public ViewResult SuccessRegistration()
        {
            return View();
        }

        public ViewResult UnSuccessRegistration()
        {
            return View();
        }

        public ViewResult unSuccessLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LogIn(string login, string password)
        {
            UsersDAO usersDao = new UsersDAO();
            if (!usersDao.ContainAccount(login, password))
            {
                return RedirectToAction("unSuccessLogin", "User");
            }
            else
            {
                return RedirectToAction("AboutUs", "User");
 
            }
        }
    }
}
