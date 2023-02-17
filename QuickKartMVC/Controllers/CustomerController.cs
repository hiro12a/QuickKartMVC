using Microsoft.AspNetCore.Mvc;

namespace QuickKartMVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult CustomerHome()
        {
            List<string> lstProducts = new List<string>();
            lstProducts.Add("Dell Inspiron");
            lstProducts.Add("Marble Chess Board");
            lstProducts.Add("Adidas shoes");
            ViewBag.TopProducts = lstProducts;
            return View();
        }
    }
}
