using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class IndexController : Controller
    {
        public IActionResult index()
        {
            return View();
        }
    }
}
