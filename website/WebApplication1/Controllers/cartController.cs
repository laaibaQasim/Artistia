using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebApplication1.Models;



namespace WebApplication1.Controllers
{
    public class cartController : Controller
    {
        public ViewResult cart()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(int itemId)
        {
            string email = Request.Cookies["LoggedInUserEmail"];
            int userId = userRepo.GetUserIdByEmail(email);
            dynamic details = Admin.GetImageById(itemId);
            Admin.AddToCart(itemId, details.OwnerId, userId);
            dynamic list = userRepo.getListOfAllCartUsers(email);

            return Ok();
        }




    }
}