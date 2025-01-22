using LoginPage.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }

        public DbSet<Usuario> Usuarios { get; set; }


    }
}
