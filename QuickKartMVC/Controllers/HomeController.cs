using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;
using QuickKartMVC.Models;
using System.Diagnostics;

namespace QuickKartMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuickKartContext _context;
        QuickKartRepository repository;

        public HomeController(QuickKartContext context)
        {
            _context = context;
            repository = new QuickKartRepository(_context);
        }
        public IActionResult Index()
        {
            return View();
        }
        public ViewResult Contact()
        {
            ViewBag.EmailId = "admin@quickKart.com";
            ViewData["ContactNumber"] = 9876543218;
            return View();
        }

        public JsonResult GetCoupons()
        {
            Random random = new Random();
            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] value = new string[5];
            string[] key = { "Arts", "Electronics", "Fashion", "Home", "Toys" };
            for(int i= 0; i < 5; i++)
            {
                // Generate a random number
                string number = "RUSH" + random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + random.Next(1, 10).ToString();
                value[i] = number;
            }
            for(int i = 0; i < 5; i++)
            {
                data.Add(key[i], value[i]);
            }
            return Json(data);
        }

        public IActionResult CheckRole(IFormCollection form)
        {
            string userId = form["name"];
            string password = form["pwd"];
            string checkbox = form["RememberMe"];
            if(checkbox == "on")
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1); // Expires in 1 day
                Response.Cookies.Append("UserId", userId, option);
                Response.Cookies.Append("Password", password, option);
            }

            string username = userId.Split("@")[0];
            byte? roleId = repository.ValidateCredentials(userId, password);
            if(roleId == 1)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("AdminHome","Admin");
            }
            else if(roleId == 2)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("CustomerHome","Customer");
            }
            return View("Login");
        }

        public IActionResult Login()
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
    }
}