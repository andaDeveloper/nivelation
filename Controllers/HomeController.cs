using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PruebaNivelacion.Models;
using System.Data;
using System.Diagnostics;
using System.Security.Cryptography.Xml;
using System.Text.Json;

namespace PruebaNivelacion.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            UserModel userOne = new UserModel("Paco");
            UserModel userTwo = new UserModel("Alfonso");
            UserModel userThree = new UserModel("Eduardo");

            List<UserModel> users = new List<UserModel> { userOne, userTwo, userThree };
            ViewBag.users = new SelectList(users,"Id", "Nick");
            return View();
        }

        [HttpPost]
        public IActionResult Index(UserModel selectedUser)
        {

            HttpContext.Session.SetString("selectedSession" ,selectedUser.Nick);
            HttpContext.Session.Clear();

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
    }
}
