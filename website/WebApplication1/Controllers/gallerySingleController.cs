using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class gallerySingleController : Controller
    {
        public ViewResult gallerySingle()
        {
            var successCookie = HttpContext.Request.Cookies["success"];
            object userEmail = null;
            if (successCookie != null)
            {
                 userEmail = HttpContext.Request.Cookies["LoggedInUserEmail"];
            }
            return View(userEmail);
        }
    }
}
