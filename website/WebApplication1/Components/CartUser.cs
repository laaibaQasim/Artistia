using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.ViewComponents
{
    public class CartUser : ViewComponent
    {


        //public IViewComponentResult Invoke()
        //{
        //    string email = HttpContext.Request.Cookies["LoggedInUserEmail"];
        //    userRepo ur = new userRepo();

        //    // Get the user based on the email from the database
        //    UserData user = ur.GetUserByEmail(email);
        //    if (user != null)
        //    {
        //        List<Cart> cartItems = ur.GetCartItems(user.Id);
        //         return View(cartItems);
        //    }
        //    return View();
        //}
        public IViewComponentResult Invoke()
        {
            string email = HttpContext.Request.Cookies["LoggedInUserEmail"];
            userRepo ur = new userRepo();

            // Get the user based on the email from the database
            UserData user = ur.GetUserByEmail(email);
            if (user != null)
            {
                List<Cart> cartItems = ur.GetCartItems(user.Id);
                return View(cartItems);
            }

            // Return an empty view if no user or cart items found
            return View(new List<Cart>());
        }
    }

    //public async Task<IViewComponentResult> InvokeAsync(int id)
    //{
    //    // Retrieve the cart items for the current user
    //    var userId = id;// Get the current user ID
    //    dynamic cartItems = await _dbContext.Carts
    //        .Include(c => c.Image)
    //        .Where(c => c.UserId == userId)
    //        .ToListAsync();

    //    // Perform any necessary calculations or additional data retrieval

    //    return View("Cart", cartItems);
    //}
}

