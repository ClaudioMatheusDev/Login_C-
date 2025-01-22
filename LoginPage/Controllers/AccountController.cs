using LoginPage.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LoginPage.Models;

namespace LoginPage.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
             _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public IActionResult home(string email, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);

            if (usuario != null) {
                HttpContext.Session.SetString("Usuario", usuario.Nome);
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Senha ou Email inválido");
            return View();
        }

    }
}
