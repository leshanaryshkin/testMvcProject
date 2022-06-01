using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using testMvcProject.Models.Resources.ImplementedResources;
using testMvcProject.DataBaseDAOs.UsersLoginsPasswords;
using testMvcProject.DataBaseDAOs.Users;
using testMvcProject.DataBaseDAOs.Resources.Furniture;
using testMvcProject.DataBaseDAOs.Resources;
using testMvcProject.DataBaseDAOs.Resources.Profile;
using testMvcProject.DataBaseDAOs.Balance;
using System.Web;
using System.Security.Claims;
using Microsoft.Owin.Security;
using testMvcProject.DataBase;
using testMvcProject.DataBaseDAOs.Service;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testMvcProject.Controllers
{
    public class AdminController : Controller
    {
        public readonly IUserManager userManager;
        public readonly IUserLoginsPasswordsManager userLoginsPasswordsManager;
        public readonly IFurnitureManager furnitureManager;
        public readonly IProfileManager profileManager;
        public readonly IBalanceManager balanceManager;
        public readonly IServiceManager ServiceManager;

        public AdminController(IUserManager userManager,
            IUserLoginsPasswordsManager userLoginsPasswordsManager,
            IFurnitureManager furnitureManager, IProfileManager profileManager,
            IBalanceManager balanceManager, IServiceManager serviceManager)
        {
            this.userManager = userManager;
            this.userLoginsPasswordsManager = userLoginsPasswordsManager;
            this.furnitureManager = furnitureManager;
            this.profileManager = profileManager;
            this.balanceManager = balanceManager;
            this.ServiceManager = serviceManager;
        }

        public ViewResult OrdersInProgress() => View();
        public ViewResult Requests() => View();
        public ViewResult UsersDB() => View(userManager);


        public ViewResult ResourcesOnStock(string trouble)
        {
            if (trouble != null)
                ViewBag.FalseAdding = "Такой ресурс уже присутствует";
            
            ResourceClass resources = new ResourceClass(furnitureManager, profileManager, balanceManager, ServiceManager);
            
            return View(resources);
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
            if (furnitureManager.ContainFurniture(name) != null)
            {
                string trouble = "inBase";
                return RedirectToAction("ResourcesOnStock", "Admin", new { trouble });
            }
            else 
            {
                DataBase.Furniture furniture = new DataBase.Furniture();
                furniture.Name = name;
                furniture.costPrice = costPrice;
                furniture.pricePerOnce = marginPrice;
                furniture.onStock = count;
                furniture.isActualPosition = true;

                furnitureManager.Create(furniture);

                return RedirectToAction("ResourcesOnStock", "Admin", new { });
            }
        }

        [HttpPost]
        public ActionResult AddProfile(string name,
            int costPrice, int marginPrice, int count)
        {
            if (profileManager.ContainProfile(name) != null)
            {
                string trouble = "inBase";
                return RedirectToAction("ResourcesOnStock", "Admin", new { trouble });
            }
            else
            {
                DataBase.Profile profile = new DataBase.Profile();
                profile.Name = name;
                profile.costPrice = costPrice;
                profile.pricePerMeter = marginPrice;
                profile.onStock = count;
                profile.isActualPosition = true;

                profileManager.Create(profile);

                return RedirectToAction("ResourcesOnStock", "Admin", new { });
            }
        }


        [HttpPost]
        public ActionResult ChangeActionPositionFurniture(string name)
        {

            furnitureManager.ChangeActualPosition(name);

            return RedirectToAction("ResourcesOnStock", "Admin");

        }

        [HttpPost]
        public ActionResult ChangeActionPositionProfile(string name)
        {

            profileManager.ChangeActualPosition(name);

            return RedirectToAction("ResourcesOnStock", "Admin");

        }

        [HttpPost]
        public ActionResult changeCurrencyBalance(string name, int Num)
        {

            balanceManager.changeCurrencyBalance(name, Num);

            return RedirectToAction("ResourcesOnStock", "Admin");

        }

        [HttpPost]
        public ActionResult AddNewService(string name, int price)
        {
            AdditionalService service = new AdditionalService();
            service.ServiceName = name;
            service.ServicePrice = price;
            service.isActual = true;
            ServiceManager.Add(service);
            return RedirectToAction("ResourcesOnStock", "Admin");
        }

        public ActionResult changeActualService(string name)
        {
            ServiceManager.ChangeActual(name);
            return RedirectToAction("ResourcesOnStock", "Admin");

        }

    }
}
