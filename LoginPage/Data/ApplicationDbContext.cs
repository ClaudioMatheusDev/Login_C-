using LoginPage.Models;
using Microsoft.EntityFrameworkCore;

namespace LoginPage.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity =>
            {

                entity.HasKey(u => u.Id);


                entity.Property(u => u.Email)
                      .IsRequired() 
                      .HasMaxLength(100); 


                entity.Property(u => u.Nome)
                      .IsRequired() 
                      .HasMaxLength(100); 
                

                entity.Property(u => u.SenhaHash)
                      .IsRequired(); 

                
                entity.HasIndex(u => u.Email)
                      .IsUnique();

               
                entity.Property(u => u.DataCadastro)
                      .IsRequired() 
                      .HasDefaultValueSql("GETUTCDATE()"); 
            });
        }
    }
}