using System;
using System.Collections.Generic;
//using Microsoft.AspNetCore.Mvc;
using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;
using testMvcProject.DataBaseDAOs.Resources;
using testMvcProject.DataBaseDAOs.Resources.Furniture;
using testMvcProject.DataBaseDAOs.Resources.Profile;
using testMvcProject.DataBaseDAOs.Balance;
using Microsoft.AspNetCore.Http;
using testMvcProject.DataBaseDAOs.OrdersDAO;

using testMvcProject.DataBaseDAOs;

using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using testMvcProject.DataBaseDAOs;
using testMvcProject.DataBaseDAOs.Service;
using testMvcProject.Models.Products.ImplemetedProducts;
using Window = testMvcProject.DataBase.Window;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMvcProject.Controllers
{
    public class UserController : Controller
    {
        public readonly IUserManager userManager;
        public readonly IUserLoginsPasswordsManager userLoginsPasswordsManager;

        public readonly IFurnitureManager furnitureManager;
        public readonly IProfileManager profileManager;
        public readonly IBalanceManager balanceManager;

        public readonly IServiceManager ServiceManager;
        public readonly IOrderManager orderManager;

        public static List<DataBase.Window> Windows { get; set; } = new List<Window>();

        public UserController(IUserManager userManager,
            IUserLoginsPasswordsManager userLoginsPasswordsManager,
            IFurnitureManager furnitureManager, IProfileManager profileManager,
            IBalanceManager balanceManager, IServiceManager ServiceManager, IOrderManager orderManager)
        {
            this.userManager = userManager;
            this.userLoginsPasswordsManager = userLoginsPasswordsManager;
            this.furnitureManager = furnitureManager;
            this.profileManager = profileManager;
            this.balanceManager = balanceManager;
            this.ServiceManager = ServiceManager;
            this.orderManager = orderManager;
        }


        [NonAction]
        private void CreateSession(string tel)
        {
            testMvcProject.DataBase.User user = userManager.Get(tel);
            HttpContext.Session.SetString("name", user.Name);
            HttpContext.Session.SetString("tel", user.telephone);
            HttpContext.Session.SetInt32("isAdmin", Convert.ToInt32(userLoginsPasswordsManager.isAdmin(tel)));
        }
        
        [HttpPost]
        public IActionResult Test(int profilePrice, int furniturePrice, int kamer, int sashes, int width, int height, double price)
        {
            DataBase.Window window = new DataBase.Window();
            window.height = height;
            window.price = Convert.ToInt32(price);
            window.width = width;
            window.FurnitureID = furnitureManager.GetByPrice(furniturePrice).ID;
            window.ProfileID = profileManager.GetProfileByPrice(profilePrice).ID;
            window.howManyCameras = kamer;
            window.howManySashes = sashes;

            Windows.Add(window);
            
            return RedirectToAction("Orders", "User");

            
        }


        public IActionResult createOrder()
        {
            if (!HttpContext.Session.Keys.Contains("tel"))
            return RedirectToAction("Authorization", "User");
            else
            {
                DataBase.Order order = new DataBase.Order();
                order.Process = "Process";
                DataBase.User user = new DataBase.User();
                user.ID = userManager.Get(HttpContext.Session.GetString("tel")).ID;
                order.UserID = user.ID;
                orderManager.Add(order);
                return RedirectToAction("AboutUs", "User");
            }


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
            return View(new ResourceClass(furnitureManager, profileManager, balanceManager, ServiceManager));
        }

        public ViewResult Orders()
        {
            return View(Windows);
        }

        public ViewResult Authorization(string telephone)
        {
            if (telephone == "404")
                ViewBag.FalseReg = "Такой пользователь не зарегистрирован";
            else if (telephone != null)
                ViewBag.FalseReg = $"Пользователь с номером {telephone} уже есть в базе";


            return View();
        }


        [HttpPost]
        public IActionResult Registration(string telephone, string name,
            string cityName, string streetName, string houseNumber)
        {

            if (userManager.ContainTel(telephone) != null)
            {
                return RedirectToAction("Authorization", "User", new {telephone});
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

            CreateSession(user.telephone);
            return RedirectToAction("SuccessRegistration", "User", new {user.Name});
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
                CreateSession(login);
                return RedirectToAction("AboutUs", "User");
            }
            
        }

        public ViewResult UserInformation()
        {
            return View(new UserInfo(userManager, userLoginsPasswordsManager));
        }

        [HttpPost]
        public IActionResult ChangePassword(string tel, string pass)
        {
            userLoginsPasswordsManager.changePass(tel, pass);
            return RedirectToAction("UserInformation", "User");
        }
    }
}
