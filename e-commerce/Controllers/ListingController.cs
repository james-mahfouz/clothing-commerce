using Microsoft.AspNetCore.Mvc;

namespace e_commerce.Controllers
{
    public class ListingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
