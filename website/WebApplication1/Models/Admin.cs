using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
    public class Admin
    {
        public static List<Image> SearchByCategory(string category)
        {
            using (var context = new ArtistiaContext())
            {
                if (category == "Mix")
                    return context.Images.ToList();
                return context.Images.Where(img => img.Category.ToLower() == category.ToLower()).ToList();
            }
        }

        public static void AddToCart(int imageId, int photographerId,int userId)
        {

            using (var context = new ArtistiaContext())
            {
                // Retrieve the image price from the database
                double imagePrice = context.Images
                .Where(image => image.Id == imageId)
                .Select(image => image.Price)
                .FirstOrDefault();

                // Create a new cart item
                var cartItem = new Cart
                {
                    ImageId = imageId,
                    UserId = userId,
                    Quantity = 1,
                    Price = imagePrice * 1 // Set the initial quantity as needed
                };

                // Multiply the quantity with the price
                cartItem.Price *= cartItem.Quantity;

                // Add the cart item to the database
                context.Carts.Add(cartItem);
                context.SaveChanges();
            
            }
        }
        public static Image GetImageById(int id)
        {
            using (var context = new ArtistiaContext())
            
                return context.Images.FirstOrDefault(image => image.Id == id);
        }
        public static List<Image> SearchByName(string name)
        {
            using (var context = new ArtistiaContext())
            {
                return context.Images
                    .Where(img => img.Name.ToLower() == name.ToLower())
                    .ToList();
            }
        }

        public static List<Image> SearchByHeight(int height)
        {
            using (var context = new ArtistiaContext()) 
            {
                return context.Images.Where(img => img.Height == height).ToList();
            }
        }
        public static List<Image> SearchByWidth(int width)
        {
            using (var context = new ArtistiaContext()) 
            {
                return context.Images.Where(img => img.Width == width).ToList();
            }
        }
        public static List<Image> SearchByOwner(int ownerId)
        {
            using (var context = new ArtistiaContext()) 
            {
                return context.Images.Where(img => img.OwnerId == ownerId).ToList();
            }
        }
        public static List<Image> SearchByPrice(double price)
        {
            using (var context = new ArtistiaContext()) 
            {
                return context.Images.Where(img => img.Price == price).ToList();
            }
        }
      
        
    }

    }
