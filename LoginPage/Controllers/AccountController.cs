using LoginPage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using LoginPage.Models;

namespace LoginPage.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher<Usuario> _passwordHasher;

        public AccountController(ApplicationDbContext context, IPasswordHasher<Usuario> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

            if (usuario != null)
            {
                var result = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, senha);
                if (result == PasswordVerificationResult.Success)
                {
                    HttpContext.Session.SetString("Usuario", usuario.Nome);
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Senha ou Email inválido");
            return View();
        }

        [HttpPost]
        public IActionResult Register(string email, string senha, string nome)
        {
            var usuario = new Usuario
            {
                Email = email,
                Nome = nome,
                Senha = _passwordHasher.HashPassword(null, senha)
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}