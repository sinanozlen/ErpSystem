using Microsoft.EntityFrameworkCore;
using ErpSystem.API.Data; 
using ErpSystem.API.Models;

var builder = WebApplication.CreateBuilder(args);

// OPENAPI / SWAGGER
builder.Services.AddOpenApi();

// DATABASE
builder.Services.AddDbContext<ErpDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// CONTROLLERS
builder.Services.AddControllers();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins(
            "http://127.0.0.1:5500",
            "http://localhost:5500"
        )
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<ErpDbContext>();
        db.Database.Migrate();
    }
}



app.UseCors("AllowFrontend");

app.MapControllers();

app.Run();
