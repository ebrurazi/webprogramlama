using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Pages.Data;
using MyAspNetApp.Pages.Models;

namespace MyAspNetApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly MongoDbContext _context;

        public RegisterModel()
        {
            _context = new MongoDbContext();
        }

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string FirstName { get; set; }
        [BindProperty]
        public string LastName { get; set; }
        [BindProperty]
        public DateTime BirthDate { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Yeni kullanıcı oluşturma
            var user = new User
            {
                Username = Username,
                Password = Password, // Şifreyi hashleyin!
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate
            };

            _context.Users.InsertOne(user);

            return RedirectToPage("/Index"); // Başarılı kayıt sonrası ana sayfaya yönlendirme
        }
    }
}
