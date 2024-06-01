using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Pages.Data;
using MyAspNetApp.Pages.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MyAspNetApp.Pages
{
    public class UrunekleModel : PageModel
    {
        private readonly MongoDbContext _context;

        public UrunekleModel(MongoDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; } = new List<Product>();

        public void OnGet()
        {
            // Fetch products from the database
            Products = _context.Products.Find(product => true).ToList();
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

                // Update the product list after adding the new product
                Products = _context.Products.Find(product => true).ToList();
            }

            return Page();
        }
    }
}
