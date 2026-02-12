using PeminjamanTempatBackend.Data;  // Pastikan untuk menambahkan namespace Data yang berisi ApplicationDbContext
using Microsoft.EntityFrameworkCore;
using PeminjamanTempatBackend.Entities;  // Pastikan nama entitas Tempat ada di Entities

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));  // Gunakan SQLite

builder.Services.AddControllers();  // Menambahkan controllers
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();  // Menambahkan Swagger untuk dokumentasi API

// Menambahkan OpenAPI (Swagger)
builder.Services.AddOpenApi();  // Untuk OpenAPI (Swagger)

// Menambahkan CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// Menggunakan CORS
app.UseCors("AllowAllOrigins");

// Mengaktifkan Swagger UI di development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();  // Menampilkan UI Swagger
}

app.UseHttpsRedirection();  // Mengaktifkan HTTPS Redirection

app.MapControllers();  // Memetakan controller ke rute yang benar

// Jalankan aplikasi
app.Run();
