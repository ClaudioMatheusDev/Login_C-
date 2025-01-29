using System;
using System.ComponentModel.DataAnnotations;

namespace LoginPage.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O email não está em um formato válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

      
        [Required]
        public string SenhaHash { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;

        public void DefinirSenha(string senha, IPasswordHasher<Usuario> passwordHasher)
        {
            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("A senha não pode ser nula ou vazia.");

            SenhaHash = passwordHasher.HashPassword(this, senha);
        }

        public bool VerificarSenha(string senha, IPasswordHasher<Usuario> passwordHasher)
        {
            if (string.IsNullOrEmpty(senha))
                return false;

            var result = passwordHasher.VerifyHashedPassword(this, SenhaHash, senha);
            return result == PasswordVerificationResult.Success;
        }
    }
}