using Microsoft.AspNetCore.Mvc;
using WebApplication1.Controllers;
namespace WebApplication1.Controllers
{
    public class shippingInfoController : Controller
    {
        public IActionResult shippingInfo()
        {
            object userEmail = HttpContext.Request.Cookies["LoggedInUserEmail"];
      
            return View(userEmail);
        }
    }
}
