using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.DAOs.ResourcesDAOs;
using testMvcProject.DAOs.UsersDAO;
using testMvcProject.Models.Resources.ImplementedResources;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;
using testMvcProject.DataBaseDAOs.Users;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMvcProject.Controllers
{
    public class AdminController : Controller
    {
        public readonly IUserManager userManager;
        public readonly IUserLoginsPasswordsManager userLoginsPasswordsManager;

        public AdminController(IUserManager userManager, IUserLoginsPasswordsManager userLoginsPasswordsManager)
        {
            this.userManager = userManager;
            this.userLoginsPasswordsManager = userLoginsPasswordsManager;
        }

        public ViewResult OrdersInProgress()
        {
            return View();
        }     
        public ViewResult Requests()
        {
            return View();
        }   
        public ViewResult ResourcesOnStock()
        {
            
            
            //!!!!!
            return View(new resourceDAO());
        }  
        public ViewResult UsersDB()
        {
            return View(userManager);
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            userLoginsPasswordsManager.Delete(id);
            userManager.Delete(id);
            return RedirectToAction("UsersDB", "Admin");
        }

        [HttpPost]
        public ActionResult AddFurniture(string name,
            int costPrice, int marginPrice, int count)
        {
            FurnitureDAO furnitureDao = new FurnitureDAO();

            Furniture furniture = new Furniture(name, costPrice, marginPrice, count);
            
            furnitureDao.AddFurniture(furniture);
            
            return RedirectToAction("ResourcesOnStock", "Admin");
        }

        
        [HttpPost]
        public ActionResult ChangeActionPosition(string name)
        {
            FurnitureDAO furnitureDao = new FurnitureDAO();
            
            furnitureDao.ChangeActual(name);
            
            return RedirectToAction("ResourcesOnStock", "Admin");
            
        }

    }
}
