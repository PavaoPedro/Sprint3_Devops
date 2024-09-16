using MAI.Models;
using MAI.Persistencia;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MAI.Controllers
{
    public class HomeController : Controller
    {
        private MAIDbContext dbContext { get; set; }


        public HomeController(MAIDbContext context)
        {
            dbContext = context;

        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {

            return View();
        }
    }
}