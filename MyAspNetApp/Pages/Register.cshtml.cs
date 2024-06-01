using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Pages.Data;
using MyAspNetApp.Pages.Models;
using MongoDB.Driver;
using System;

namespace MyAspNetApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly MongoDbContext _dbContext;

        public RegisterModel(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public string Username { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        [BindProperty]
        public string FirstName { get; set; } = string.Empty;

        [BindProperty]
        public string LastName { get; set; } = string.Empty;

        [BindProperty]
        public DateTime BirthDate { get; set; } = DateTime.Now;

        [BindProperty]
        public string Role { get; set; } = string.Empty;

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
            {
                Username = Username,
                Password = Password,
                FirstName = FirstName,
                LastName = LastName,
                BirthDate = BirthDate,
                Roles = new List<string> { Role }
            };

            _dbContext.Users.InsertOne(user);

            return RedirectToPage("/Index");
        }
    }
}
