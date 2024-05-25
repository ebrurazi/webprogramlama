using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MyAspNetApp.Pages.Data;
using MyAspNetApp.Pages.Models;

namespace MyAspNetApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly MongoDbContext _context;

        public LoginModel()
        {
            _context = new MongoDbContext();
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }

        // Hata mesajı için bir özellik ekleyin
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Kullanıcı doğrulama
            var user = _context.Users.Find(u => u.Username == Username && u.Password == Password).FirstOrDefault();
            if (user == null)
            {
                ErrorMessage = "Böyle bir kayıt bulunmamaktadır.";
                return Page();
            }

            return RedirectToPage("/Index"); // Başarılı giriş sonrası ana sayfaya yönlendirme
        }
    }
}
