using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using LibreriaDigital.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<LibreriaDigitalAppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;

//     try
//     {
//         var context = services.GetRequiredService<LibreriaDigitalAppDbContext>();
//         if (context.Database.GetPendingMigrations().Any())
//         {
//             context.Database.Migrate();
//         }
//     }
//     catch (Exception ex)
//     {
//         // Aquí puedes manejar cualquier error que pueda surgir, por ejemplo, utilizando un logger
//         var logger = services.GetRequiredService<ILogger<Program>>();
//         logger.LogError(ex, "Un error ocurrió al aplicar las migraciones.");
//     }
// }

// Configure the HTTP request pipeline.
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
