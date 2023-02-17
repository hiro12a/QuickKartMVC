using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;

namespace QuickKartMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly QuickKartContext _context;
        QuickKartRepository repository;
        private readonly IMapper _mapper;

        public CategoryController(QuickKartContext context)
        {
            _context = context;
            repository = new QuickKartRepository(_context);
        }
        public IActionResult ViewCategory()
        {
            IEnumerable<Categories> category = repository.GetCategories();
            return View(category);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Categories obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("ViewCategory");
            }
            return View(obj);
        }
        public IActionResult EditCategory(byte? id)
        {
            var obj = _context.Categories.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateCategories(Categories obj)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(obj);
                _context.SaveChanges();
                return RedirectToAction("ViewCategory");
            }

            return View(obj);
        }

        public IActionResult DeleteCategory(byte? id)
        {
            var obj = _context.Categories.Find(id);
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveDeleteCategory(Categories obj)
        {
            _context.Categories.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("ViewCategory");
        }
    }
}
