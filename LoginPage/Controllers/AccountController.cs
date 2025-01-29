using LoginPage.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using LoginPage.Models;
using Microsoft.AspNetCore.Http;

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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ModelState.AddModelError("", "Email e senha são obrigatórios.");
                return View();
            }

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

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string senha, string nome)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(nome))
            {
                ModelState.AddModelError("", "Todos os campos são obrigatórios.");
                return View();
            }

            var usuarioExistente = _context.Usuarios.Any(u => u.Email == email);
            if (usuarioExistente)
            {
                ModelState.AddModelError("", "Este email já está em uso.");
                return View();
            }

            var usuario = new Usuario
            {
                Email = email,
                Nome = nome,
                Senha = _passwordHasher.HashPassword(null, senha)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}