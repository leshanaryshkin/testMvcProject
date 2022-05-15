using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.Models.DAOs.UsersDAO;

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
            return View();
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

    }
}
