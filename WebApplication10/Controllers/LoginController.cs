using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class LoginController : Controller
    {
        public LoginController()
        {
            if (users == null)
            {
                users = new List<UserModel>()
                 {
                      new UserModel () {UserName="user1", Password="password@123"},
                      new UserModel () {UserName="user2", Password="password@123"}

                 };
            }
        }
        List<UserModel> users = null;
        public IActionResult Login()
        {
            if(TempData["msg"]!=null)
                    {
                ViewBag.msg1 = TempData["msg"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            var user = users.FirstOrDefault(x => x.UserName == userModel.UserName
            && x.Password == userModel.Password);
            if (user != null)
            {
                this.HttpContext.Session.SetString("user", user.UserName);
                this.HttpContext.Session.SetString("role", user.Password);
                    
                return Redirect("~/Home1");
            }
            else
            {
                ViewBag.msg = "Invalid User";
                return View();
            }
        }
    }

  }
