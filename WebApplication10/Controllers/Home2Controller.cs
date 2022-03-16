using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication10.ExtensionMethods;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class Home2Controller : Controller
    {
        
          
        
    
        List<UserModel> users = null;

        private readonly IServiceProvider _service;
        public Home2Controller( IServiceProvider service)
        {
            if (users == null)
            {
                users = new List<UserModel>()
                 {
                      new UserModel () {UserName="user1", Password="password@123"},
                      new UserModel () {UserName="user2", Password="password@123"}

                 };
            }
            _service = service;
        }
        public IActionResult Index()
        {
            string name = this.HttpContext.Session.GetString("user");
            if (name == null)
            {
                return Redirect("~/Home2/Login");
            }
            else
            {
                var t2 = (Test)_service.GetService(typeof(Test));
                string t1 = t2.GetValues();
                return View();
            }
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserModel userModel)
        {
            var user = users.FirstOrDefault(x => x.UserName == userModel.UserName
            && x.Password == userModel.Password);
            if (user != null)
            {
                var t2 = (Test)_service.GetService(typeof(Test));
                t2.SetVlaues(user.UserName);

                return Redirect("~/Home2");
            }
            else
            {
                ViewBag.msg = "Invalid User";
                return View();
            }
        }
    }
}
