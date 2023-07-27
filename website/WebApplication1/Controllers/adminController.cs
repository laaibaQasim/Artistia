using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult admin()
        {
            var request=HttpContext.Request.Cookies["admin"];
            if (request != null)
            {
                return View();
            }
            return RedirectToAction("Login","Login");
        }

        [HttpPost]
        public IActionResult AddImage(Image image)
        {

            ArtistiaContext context = new ArtistiaContext();
            image.Category = char.ToUpper(image.Name[0]) + image.Name.Substring(1).ToLower();
            context.Images.Add(image);
            context.SaveChanges();
            return View("admin");

        }
        
        [HttpPost]
        public ActionResult RemoveCartItem(string id)
        {
            using (var context = new ArtistiaContext())
            {
                if (int.TryParse(id, out int itemId))
                {
                    // Retrieve the cart item from the database using the provided id
                    Cart cartItemToRemove = context.Carts.FirstOrDefault(item => item.ImageId == itemId);
                    if (cartItemToRemove != null)
                    {
                        // Remove the cart item from the database
                        context.Carts.Remove(cartItemToRemove);
                        context.SaveChanges();

                        // Call the helper method to remove the cart item from the database
                        RemoveCartItemFromDatabase(id);

                        return Content("success");
                    }
                }

                return Content("error");
            }
        }

        // Helper method to remove the cart item from the database
        private void RemoveCartItemFromDatabase(string id)
        {
            using (var context = new ArtistiaContext())
            {
                if (int.TryParse(id, out int itemId))
                {
                    // Retrieve the cart item from the database using the provided id
                    Cart cartItem = context.Carts.FirstOrDefault(item => item.ImageId == itemId);
                    if (cartItem != null)
                    {
                        // Remove the cart item from the database
                        context.Carts.Remove(cartItem);
                        context.SaveChanges();
                    }
                }
            }
        }


        [HttpPost]
        public IActionResult DeleteImage(string name, string imgLink)
        {
            using (var context = new ArtistiaContext())
            {
                var image = context.Images.FirstOrDefault(i => i.Name == name && i.ImgLink == imgLink);

                if (image != null)
                {
                    context.Images.Remove(image);
                    context.SaveChanges();
                    return RedirectToAction("Admin");
                }
            }
            //display red wala error
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult UpdateImage(string Name, int OwnerId, string ImgLink, int Price, int Height, int Width, string Category)
        {
            using (var context = new ArtistiaContext())
            {
                var image = context.Images.FirstOrDefault(i => i.Name == Name && i.ImgLink == ImgLink);

                if (image != null)
                {
                    if (!string.IsNullOrEmpty(Name))
                        image.Name = Name;

                    if (OwnerId != 0)
                        image.OwnerId = OwnerId;

                    if (!string.IsNullOrEmpty(ImgLink))
                        image.ImgLink = ImgLink;

                    if (Price != 0)
                        image.Price = Price;

                    if (Height != 0)
                        image.Height = Height;

                    if (Width != 0)
                        image.Width = Width;

                    if (!string.IsNullOrEmpty(Category))
                        image.Category = Category;

                    context.SaveChanges();
                }
            }

            return RedirectToAction("Admin");
        }
       
        public IActionResult GetCartTotal()
        {
            string email = Request.Cookies["LoggedInUserEmail"];


            // Get the user ID using the email
            int userId = userRepo.GetUserIdByEmail(email);

            // Check if the user ID is valid
            if (userId != 0)
            {
                // Get all cart items for the user
                var cartItems = userRepo.getListOfAllCartUsers(email);

                // Calculate the cart total
                dynamic total = 0;
                foreach (var item in cartItems)
                {
                    total = total + item.Price;
                }

                return new JsonResult(new { total });
            }

            // Return an empty response if the user ID is not valid
            return new JsonResult(new { total = 0 });
        }

    }

}