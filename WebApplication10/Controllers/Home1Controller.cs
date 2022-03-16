using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication10.Controllers
{
    public class Home1Controller : Controller
    {
        public IActionResult Index()
        {
            string name = this.HttpContext.Session.GetString("user");
            if (name == null)
            {
                TempData["msg"] = "Sessio is not available";
                return Redirect("~/Login/Login");
            }
            else
                return View();
    
        }
    }
}
