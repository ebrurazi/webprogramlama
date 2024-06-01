using Microsoft.AspNetCore.Mvc;
using MyAspNetApp.Models;

namespace MyAspNetApp.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Kayıt işlemleri
                // Örneğin, veritabanına kayıt ekleme işlemleri burada yapılabilir.
            }
            return View(model);
        }
    }
}
