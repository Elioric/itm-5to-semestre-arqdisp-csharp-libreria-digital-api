using Microsoft.EntityFrameworkCore;
using LibreriaDigital.Domain.Entities;

namespace LibreriaDigital.Infrastructure.Data
{
    public class LibreriaDigitalAppDbContext : DbContext
    {
        public LibreriaDigitalAppDbContext(DbContextOptions<LibreriaDigitalAppDbContext> options) : base(options) { }

        // Mapeo a entidades de Domain
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo 1 a muchos: Un Usuario tiene muchos Libros
            modelBuilder.Entity<Book>()
                .HasOne(b => b.User)
                .WithMany(u => u.Books)
                .HasForeignKey(b => b.UserId);

            // // Mapeo explícito a nombres de tabla
            // modelBuilder.Entity<User>().ToTable("Users");
            // modelBuilder.Entity<Book>().ToTable("Books");
        }
    }
}