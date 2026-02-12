using PeminjamanTempatBackend.Data;  // Pastikan untuk menambahkan namespace Data yang berisi ApplicationDbContext
using Microsoft.EntityFrameworkCore;
using PeminjamanTempatBackend.Entities;  // Pastikan nama entitas Tempat ada di Entities

var builder = WebApplication.CreateBuilder(args);

// Tambahkan DbContext SQLite
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Tambahkan CORS agar bisa diakses Frontend React
builder.Services.AddCors(options => {
    options.AddPolicy("AllowReact", policy => {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowReact"); // Gunakan CORS
app.UseAuthorization();
app.MapControllers();
app.Run();