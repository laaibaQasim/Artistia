using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class galleryController : Controller
    {
        public ViewResult gallery()
        {
            dynamic list=GetAllImages();
            return View("~/Views/Gallery/gallery.cshtml", list);
        }
        public List<Image> GetAllImages()
        {
            using (var context = new ArtistiaContext())
            {
                return context.Images.ToList();
            }
        }
        [HttpPost]
        public IActionResult getList(string name)
        {
            if (name != null)
            {
                dynamic list = Admin.SearchByName(name);
                foreach (dynamic item in list)
                {
                    Console.WriteLine(item.ImgLink);
                }
                return View("~/Views/Gallery/gallery.cshtml", list);

            }
            return View("~/Views/Gallery/gallery.cshtml");
        }

        [HttpPost]
        public IActionResult filter(string priceFilter, int heightFilter, int widthFilter, List<string> categoryFilter)
        {
            // Call the necessary functions to extract data from the database based on the selected filters
            var filteredData = FilterData(priceFilter, heightFilter, widthFilter, categoryFilter);

            // Pass the filtered data to the view
            return View("Gallery", filteredData);
        }
        private List<Image> FilterData(string priceFilter, int heightFilter, int widthFilter, List<string> categoryFilter)
        {
            ArtistiaContext context = new ArtistiaContext();
            var filteredData = context.Images.ToList(); // Replace with your actual logic

            // Apply filters based on the selected options
            // Example:
            if (priceFilter == "lowToHigh")
            {
                filteredData = filteredData.OrderBy(img => img.Price).ToList();
            }
            else if (priceFilter == "highToLow")
            {
                filteredData = filteredData.OrderByDescending(img => img.Price).ToList();
            }
            if(heightFilter==0 && widthFilter!=0)
            {
                filteredData = filteredData.Where(img => img.Width <= widthFilter).ToList();
            }
            else if(heightFilter!=0 && widthFilter==0)
            {
                filteredData = filteredData.Where(img => img.Height <= heightFilter).ToList();
            }
            else if(widthFilter!=0 && heightFilter!=0)
                filteredData = filteredData.Where(img => img.Height <= heightFilter && img.Width <= widthFilter).ToList();

            if (categoryFilter != null && categoryFilter.Count > 0)
            {
                filteredData = filteredData.Where(img => categoryFilter.Contains(img.Category)).ToList();
            }

            return filteredData;
        }

    }
}
