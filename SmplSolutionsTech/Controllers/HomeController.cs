using Microsoft.AspNetCore.Mvc;
using SmplSolutionsTech.Helpers.Classes;
using SmplSolutionsTech.Models;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace SmplSolutionsTech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailHelper _emailHelper;

        public HomeController(ILogger<HomeController> logger, IEmailHelper emailHelper)
        {
            _logger = logger;
            _emailHelper = emailHelper;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            await _emailHelper.SendMessageWithoutReplyToAsync("buss.kyle@gmail.com", "Hello World!", "This is an email from SmplSolutionsTech!");
            return RedirectToAction("Index");
        }
    }
}