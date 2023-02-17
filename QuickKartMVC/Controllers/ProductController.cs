using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;

namespace QuickKartMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly QuickKartContext _context;
        private readonly IMapper _mapper;

        QuickKartRepository repository;
        public ProductController(QuickKartContext context, IMapper mapper)
        {
            _context = context;
            repository = new QuickKartRepository(_context);
            _mapper = mapper;
        }
        public IActionResult ViewProduct()
        {
            var lstProduct = repository.GetProducts();
            List<Products> products = new List<Products>();
            foreach (var product in lstProduct)
            {
                products.Add(_mapper.Map<Products>(product));
            }
            return View(products);
        }

        // Add Product
        public IActionResult AddProduct()
        {
            string productId = repository.GetNextProductId();
            ViewBag.NextProductId = productId;
            return View();
        }

        // Save added product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Products products)
        {
            _context.Products.Add(products);
            _context.SaveChanges();
            return RedirectToAction("ViewProduct");
        }
        public IActionResult UpdateProduct(string id)
        {
            var products = _context.Products.Find(id);
            return View(products);
        }

        // Save added product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(Products products)
        {
            _context.Products.Update(products);
            _context.SaveChanges();
            return RedirectToAction("ViewProduct");
        }

        public IActionResult DeleteProduct(Models.Products id)
        {
            return View(id);
        }

        // Save added product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SavedDeleteProduct(string productId)
        {
            repository.DeleteProduct(productId);
            return RedirectToAction("ViewProduct");
        }
    }
}
