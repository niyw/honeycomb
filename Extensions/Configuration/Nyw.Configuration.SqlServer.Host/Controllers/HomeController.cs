using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Nyw.Configuration.SqlServer.Host.Models;

namespace Nyw.Configuration.SqlServer.Host.Controllers {
    public class HomeController : Controller {
        public readonly IConfiguration _configuration = null;
        public HomeController(IConfiguration configuration) {
            this._configuration = configuration;
        }
        public IActionResult Index() {
            return View();
        }

        public IActionResult About() {
            ViewData["TestDb1"] = _configuration.GetConnectionString("TestDb1");
            ViewData["DefaultConnection"] = _configuration.GetConnectionString("DefaultConnection");
            ViewData["trademark"] = _configuration.GetValue<string>("trademark");
            ViewData["starship:length"] = _configuration.GetValue<float>("starship:length");
            ViewData["starship:commissioned"] = _configuration.GetValue<bool>("starship:commissioned");
            ViewData["section2:subsection0:key0"] = _configuration.GetValue<string>("section2:subsection0:key0");
            return View();
        }

        public IActionResult Contact() {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy() {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
