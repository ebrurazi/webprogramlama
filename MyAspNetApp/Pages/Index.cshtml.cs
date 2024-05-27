using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

public class IndexModel : PageModel
{
    public List<Product> Products { get; set; } = new List<Product>();

    public void OnGet()
    {
        // Mevcut ürünleri yükleyin (örnek olarak sabit ürünler ekliyoruz)
        Products.Add(new Product { Name = "Ürün 1", Price = 100, ImageUrl = "https://via.placeholder.com/200x250" });
        Products.Add(new Product { Name = "Ürün 2", Price = 150, ImageUrl = "https://via.placeholder.com/200x250" });
        Products.Add(new Product { Name = "Ürün 3", Price = 200, ImageUrl = "https://via.placeholder.com/200x250" });
        Products.Add(new Product { Name = "Ürün 4", Price = 250, ImageUrl = "https://via.placeholder.com/200x250" });
        Products.Add(new Product { Name = "Ürün 5", Price = 200, ImageUrl = "https://via.placeholder.com/200x250" });
        Products.Add(new Product { Name = "Ürün 6", Price = 200, ImageUrl = "https://via.placeholder.com/200x250" });
    }

    public async Task<IActionResult> OnPostAsync(string productName, string productPrice, IFormFile productImage)
    {
        if (productImage != null && !string.IsNullOrEmpty(productName) && !string.IsNullOrEmpty(productPrice))
        {
            var filePath = Path.Combine("wwwroot", "uploads", productImage.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await productImage.CopyToAsync(stream);
            }

            Products.Add(new Product
            {
                Name = productName,
                Price = decimal.Parse(productPrice),
                ImageUrl = $"/uploads/{productImage.FileName}"
            });
        }

        return RedirectToPage();
    }
}

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
}
