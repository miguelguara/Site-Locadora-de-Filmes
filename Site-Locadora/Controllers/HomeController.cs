using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Site_Locadora.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Privacy()
        {
            return View();
        }
     
    }
}
