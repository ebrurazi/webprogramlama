using Microsoft.AspNetCore.Mvc.RazorPages;
using MyAspNetApp.Pages.Data;
using MyAspNetApp.Pages.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MyAspNetApp.Pages
{
    public class UserDashboardModel : PageModel
    {
        private readonly MongoDbContext _context;

        public UserDashboardModel(MongoDbContext context)
        {
            _context = context;
        }

        public List<Product> Products { get; set; }

        public void OnGet()
        {
            Products = _context.Products.Find(product => true).ToList();
        }
    }
}
