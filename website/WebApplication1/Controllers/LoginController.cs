using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class LoginController : Controller
    {
        public ViewResult login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserData user)
        {
            string email = user.Email;
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            HttpContext.Response.Cookies.Append("LoggedInUserEmail", user.Email);

            userRepo ur = new userRepo();
            ur.login(user);
            if (ur.IsValidUser(user))
            {
                HttpContext.Response.Cookies.Append("success", "Successfully Logged In");
                //TempData["success"] = "Successfully Logged In";

                return Redirect("~/Home/home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid username or password.";
                return View("login");
            }
        }

        [HttpPost]
        public IActionResult SignUp(UserData user)

        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            string email = user.Email; // Replace with the actual email entered by the user
            HttpContext.Response.Cookies.Append("LoggedInUserEmail", user.Email);

            HttpContext.Response.Cookies.Append("success", "Successfully Logged In");
            // TempData["success"] = "Successfully Logged In";
            userRepo ur = new userRepo();
            ur.login(user);
            ur.AddUser(user);
            return Redirect("~/Home/home");
        }

        [HttpPost]
        public IActionResult LogOut()
        {
            string email = Request.Cookies["LoggedInUserEmail"];
           
            userRepo ur = new userRepo();
           if( ur.LogOut(email))
                HttpContext.Response.Cookies.Delete("admin");
            HttpContext.Response.Cookies.Delete("success");
          

            return Redirect("~/Home/home");
        }
        [HttpPost]
        public IActionResult AdminLogin(UserData user)
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
            string email = user.Email; 
            HttpContext.Response.Cookies.Append("LoggedInUserEmail", user.Email);
          

            userRepo ur = new userRepo();
            if (ur.IsValidUser(user))
            {
                HttpContext.Response.Cookies.Append("success", "Successfully Logged In");
                HttpContext.Response.Cookies.Append("admin", "this is admin");
                // TempData["admin"] = "true";
                //TempData["success"] = "Successfully Logged In";
                ur.login(user);
                return Redirect("~/Home/home");
            }
            else
            {
                TempData["ErrorMessage"] = "Invalid username or password.";
                user.Status = false;
                return Redirect("~/Login/login");
            }
        }
    }
}
