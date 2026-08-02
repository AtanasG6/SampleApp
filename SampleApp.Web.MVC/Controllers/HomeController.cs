using Microsoft.AspNetCore.Mvc;
using SampleApp.Web.MVC.Models;
using System.Diagnostics;

namespace SampleApp.Web.MVC.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet("privacy")]
        public IActionResult Privacy()
        {
            return this.View();
        }

        [HttpGet("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
