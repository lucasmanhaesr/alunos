using System.Diagnostics;
using Alunos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alunos.Controllers
{
    public class HomeController : Controller
    {
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
