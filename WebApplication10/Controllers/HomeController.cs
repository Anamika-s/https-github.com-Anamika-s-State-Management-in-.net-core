using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string userName = Request.Cookies["username"];
            return View("Index", userName);
        }

        [HttpPost]
         public IActionResult Index(string username)
        {

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddMinutes(10);
            Response.Cookies.Append("username", username, options);

            return RedirectToAction(nameof(Index));

        }

        public IActionResult  DeleteCookie()
        {
            Response.Cookies.Delete("username");
            return View("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
