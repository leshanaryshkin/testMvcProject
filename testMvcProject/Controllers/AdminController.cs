using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.Models.DAOs.ResourcesDAOs;
using testMvcProject.Models.DAOs.UsersDAO;
using testMvcProject.Models.Resources.ImplementedResources;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMvcProject.Controllers
{
    public class AdminController : Controller
    {
        public AdminController() { }

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
            return View(new resourceDAO());
        }  
        public ViewResult UsersDB()
        {
            return View(new UsersDAO());
        }

        [HttpPost]
        public ActionResult DeleteUser(int id)
        {
            Console.WriteLine($"QU{id}");
            UsersDAO usersDao = new UsersDAO();
            usersDao.deleteUser(id);
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
