using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;

namespace QuickKartMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly QuickKartContext _context;
        QuickKartRepository repository;
        public UserController(QuickKartContext context)
        {
            _context = context;
            repository = new QuickKartRepository(_context);
        }

        public IActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
