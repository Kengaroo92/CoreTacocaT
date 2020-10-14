using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreTacocaT.Models;

namespace CoreTacocaT.Controllers
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
            return View();
        }

        public IActionResult Code()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(string userText)
        {
            if(string.IsNullOrWhiteSpace(userText))
            { 
                return View();
            }

            var result = userText.ToLower().Replace(" ", "");
            var reverse = string.Join("", result.Reverse().ToArray());
            ViewData["Input"] = userText;
            ViewData["Reversed"] = reverse;
            ViewData["Result"] = userText == reverse;

            return View();

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
