using System.Diagnostics;
using Alunos.Logging;
using Alunos.Models;
using Microsoft.AspNetCore.Mvc;

namespace Alunos.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICustomLogger _customLogger;

        public HomeController(ICustomLogger customLogger) {
            // Em vez de fazer isso:
            // _customLogger = new MockLogger();
            // Faça isso, pois o .NET injeta a dependencia MockLogger() automaticamente
            _customLogger = customLogger;
        }

        public IActionResult Index()
        {
            _customLogger.log("Log customizado chegou na controller");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
