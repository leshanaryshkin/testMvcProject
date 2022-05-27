using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.DAOs.ProductsDAO;
using testMvcProject.DAOs.ResourcesDAOs;
using testMvcProject.DAOs.UsersDAO;
using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;
using System.Web;
using testMvcProject.DataBaseDAOs.Resources;
using testMvcProject.DataBaseDAOs.Resources.Furniture;
using testMvcProject.DataBaseDAOs.Resources.Profile;




// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMvcProject.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserManager userManager;
        public readonly IUserLoginsPasswordsManager userLoginsPasswordsManager;

        public readonly IFurnitureManager furnitureManager;
        public readonly IProfileManager profileManager;

        public UserController(IUserManager userManager,
            IUserLoginsPasswordsManager userLoginsPasswordsManager,
            IFurnitureManager furnitureManager, IProfileManager profileManager)
        {
            this.userManager = userManager;
            this.userLoginsPasswordsManager = userLoginsPasswordsManager;
            this.furnitureManager = furnitureManager;
            this.profileManager = profileManager;
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
            return View(new ResourceClass(furnitureManager, profileManager));
        }

        public ViewResult Orders()
        {
            //!!
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

            if (userManager.ContainTel(telephone) != null)
            {
                return RedirectToAction("Authorization", "User", new{telephone});
            }
            

            string Adress = cityName + " " + streetName + " " + houseNumber;

            DataBase.User user = new DataBase.User();
            user.Name = name;
            user.Adress = Adress;
            user.telephone = telephone;

            userManager.Create(user);

            int? id = userManager.ContainTel(telephone);

            DataBase.UserLoginPassword user1 = new DataBase.UserLoginPassword();
            user1.ID = Convert.ToInt32(id); 
            user1.Is_admin = false;
            user1.Login = telephone;
            user1.Password = name;

            userLoginsPasswordsManager.Create(user1);
            
            return RedirectToAction("SuccessRegistration", "User", new{user.Name});
        }
        
    

        public ViewResult SuccessRegistration(string name)
        {
            ViewBag.Name = $"{name}";
            return View();
        }

        

        [HttpPost]
        public IActionResult LogIn(string login, string password)
        {
            
            if (!userLoginsPasswordsManager.ContainAccount(login, password))
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
