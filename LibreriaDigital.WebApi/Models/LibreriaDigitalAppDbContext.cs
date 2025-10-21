using Microsoft.EntityFrameworkCore;

namespace LibreriaDigital.WebApi.Models
{
    public class LibreriaDigitalAppDbContext : DbContext
    {
        public LibreriaDigitalAppDbContext(DbContextOptions<LibreriaDigitalAppDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().ToTable("Users");
        //    modelBuilder.Entity<Book>().ToTable("Books");
        //}
    }
}