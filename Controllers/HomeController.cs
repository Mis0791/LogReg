using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LogReg.Models;
using DbConnection;


namespace LogReg.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = new List<string>();
            return View();
        }

        [HttpGet]
        [Route("success")]
        public IActionResult Success()
        {
            return View("Success");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register(UserViewModel model)
        {
            if(ModelState.IsValid)
            {
                RegisterUser NewUser = new RegisterUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Password = model.Password
                };
                string query = $"INSERT INTO user (firstname, lastname, email, password) VALUES ('{model.FirstName}', '{model.LastName}', '{model.Email}', '{model.Password}')";
                DbConnector.Execute(query);
                return RedirectToAction("Success");
            } else{
                ViewBag.errors = ModelState.Values;
                return View("Index");  
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(string Email, string Password)
        {
            ViewBag.errors = new List<string>();
            List<Dictionary<string, object>> user = DbConnector.Query($"SELECT iduser, password FROM user WHERE email = '{Email}'"); 
            if(user.Count == 0)
            {
                ViewBag.usererror = "Email not found";
            } else if(user[0]["password"].ToString() != Password)
            {
                ViewBag.Password = "Invalid Password";

            } else if(user[0]["password"].ToString() == Password){

                return RedirectToAction("Success");
            }
            return View("Index");
        }
    }
}
