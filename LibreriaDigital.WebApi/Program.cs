using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;
using LibreriaDigital.Application.Interfaces;
using LibreriaDigital.Infrastructure.Repositories; 
using LibreriaDigital.Infrastructure.Data; 
using LibreriaDigital.Application; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibreriaDigitalAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(MappingProfile).Assembly);

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<LibreriaDigitalAppDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
        context.Database.Migrate();
            }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un error ocurrió al aplicar las migraciones.");
    }
}

// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseRouting();

app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    }
);

app.UseHttpsRedirection();

app.Run();