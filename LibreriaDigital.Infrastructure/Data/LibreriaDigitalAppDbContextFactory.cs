using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace LibreriaDigital.Infrastructure.Data
{
    public class LibreriaDigitalAppDbContextFactory : IDesignTimeDbContextFactory<LibreriaDigitalAppDbContext>
    {
        public LibreriaDigitalAppDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true) 
                .AddJsonFile("appsettings.json", optional: true) 
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<LibreriaDigitalAppDbContext>();
            
            builder.UseSqlServer(connectionString); 

            return new LibreriaDigitalAppDbContext(builder.Options);
        }
    }
}