using Microsoft.AspNetCore.Mvc;

namespace QuickKartMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminHome()
        {
            List<string> lstProducts = new List<string>();
            lstProducts.Add("See and Say");
            lstProducts.Add("Wall Stickers");
            lstProducts.Add("Curtains");
            ViewBag.TopProducts = lstProducts;
            return View();
        }
    }
}
