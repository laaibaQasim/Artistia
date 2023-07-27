using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Models
{
    public class userRepo
    {
        public bool IsValidUser(UserData user)
        {
            using (var context = new ArtistiaContext())
            {
                var User = context.UserDatas.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                return User != null;
            }
        }
        public void login(UserData user)
        {
            var context = new ArtistiaContext();
            if (IsValidUser(user))
            {
                var User = context.UserDatas.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
                if (User != null)
                {
                    User.Status = true;
                    context.SaveChanges();
                }
            }
        }
        public bool LogOut(string email)
        {
            using (var context = new ArtistiaContext())
            {
                var user = context.UserDatas.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    if(user.IsAdmin==true)
                    {
                        return true;
                    }
                    user.Status = false;
                    context.SaveChanges();
                    return false;
                }//ALSO NEED TO REMOVE CART}
                return false;
            }
        }
        public void AddUser(UserData user)
        {

            using (var context = new ArtistiaContext())
            {
                user.Status = true;
                context.UserDatas.Add(user);
                context.SaveChanges();
            }
        }
        public static List<Cart> getListOfAllCartUsers(string email)
        {
            
            userRepo ur = new userRepo();

            // Get the user based on the email from the database
            UserData user = ur.GetUserByEmail(email);
            if (user != null)
            {
                List<Cart> cartItems = ur.GetCartItems(user.Id);
                return cartItems;
            }
            return null;
        }
        public static int GetUserIdByEmail(string email)
        {
            using (var context = new ArtistiaContext())
            {
                var user = context.UserDatas.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    return user.Id;
                }
            }
            return 0; // Return a default value if user not found
        }
        public UserData GetUserByEmail(string email)
        {
            using (var context = new ArtistiaContext())
            {
                return context.UserDatas.FirstOrDefault(u => u.Email == email);
            }
        }

        public List<Cart> GetCartItems(int userId)
        {
            using (var context = new ArtistiaContext())
            {
                return context.Carts
                    .Include(c => c.Image)
                    .Where(c => c.UserId == userId)
                    .ToList();
            }
        }
    }
}