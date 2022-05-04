﻿using System;
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
        public string Authorization2()
        {
            string telephone = Request.Form.FirstOrDefault(p => p.Key == "telephone").Value;
            string password = Request.Form.FirstOrDefault(p =>p.Key == "password").Value;
            return $"log {telephone} и pass {password}";
        }

        


    }
}
