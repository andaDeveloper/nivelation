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
        public List<UserModel> users;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        private List<UserModel> initialize()
        {
            UserModel userOne = new UserModel("Paco", 1);
            UserModel userTwo = new UserModel("Alfonso", 2);
            UserModel userThree = new UserModel("Eduardo", 3);

            users = new List<UserModel> { userOne, userTwo, userThree };

            return users;

        }

        public ActionResult Index()
        {

            users = initialize();
            ViewBag.users = new SelectList(users,"Id", "Nick");
            return View();
        }

        [HttpPost]
        public IActionResult SessionMaker()
        {
            users = initialize();

            HttpContext.Session.Clear();
            string formValue = HttpContext.Request.Form["ejemplo"];
            var formObject = users.FirstOrDefault(user => user.Id == int.Parse(formValue)); 
            HttpContext.Session.SetString("selectedSession" , formObject.Nick);


            return RedirectToAction("Books", "Book");
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
