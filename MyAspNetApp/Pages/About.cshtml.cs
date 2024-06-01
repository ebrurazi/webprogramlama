using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace MyAspNetApp.Pages
{
    public class AboutUsModel : PageModel
    {
        private readonly ILogger<AboutUsModel> _logger;

        public AboutUsModel(ILogger<AboutUsModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
