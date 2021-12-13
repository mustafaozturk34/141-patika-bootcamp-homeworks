using Homework2_Extensions_WebApp.Filter;
using Homework2_Extensions_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Homework2_Extensions_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [LoginFilter]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Kullanıcı Kontrol
        [HttpGet("admin")]
        [LoginFilter]
        public string AdminPanel()
        {
            return "Welcome User";
        }

        [HttpGet("worker")]
        [LoginFilter]
        public string WorkerPanel()
        {
            return "Welcome User";
        }

        [HttpGet("seller")]
        [LoginFilter]
        public string SellerPanel()
        {
            return "Welcome User";
        }

        public string SuccessfulTransaction()
        {
            return "successful transaction";
        }

        public string UnauthorizedAction()
        {
            return "Unauthorized Action";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
