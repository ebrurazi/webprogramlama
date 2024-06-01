using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyAspNetApp.Pages
{
    public class SellerModel : PageModel
    {
        public string SellerName { get; set; } = "Örnek Satıcı";
        public string SellerDetails { get; set; } = "Bu satıcı, çeşitli ayakkabı ürünleri satmaktadır.";

        public void OnGet()
        {
        }
    }
}
