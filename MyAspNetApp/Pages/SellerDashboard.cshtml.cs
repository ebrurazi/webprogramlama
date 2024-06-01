using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Pages.Data;
using MyAspNetApp.Pages.Models;
using MongoDB.Driver;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyAspNetApp.Pages
{
    public class SellerDashboardModel : PageModel
    {
        private readonly MongoDbContext _context;

        public SellerDashboardModel(MongoDbContext context)
        {
            _context = context;
        }

        public string SellerName { get; set; } = "Örnek Satıcı";
        public string SellerDetails { get; set; } = "Bu satıcı, çeşitli ayakkabı ürünleri satmaktadır.";

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string productName, string productPrice, IFormFile productImage)
        {
            if (productImage != null && !string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productPrice))
            {
                var uploadsFolderPath = Path.Combine("wwwroot", "uploads");
                if (!Directory.Exists(uploadsFolderPath))
                {
                    Directory.CreateDirectory(uploadsFolderPath);
                }

                var filePath = Path.Combine(uploadsFolderPath, productImage.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await productImage.CopyToAsync(stream);
                }

                var product = new Product
                {
                    Name = productName,
                    Price = decimal.Parse(productPrice),
                    ImageUrl = $"/uploads/{productImage.FileName}"
                };

                await _context.Products.InsertOneAsync(product);
            }

            return Page();
        }
    }
}
