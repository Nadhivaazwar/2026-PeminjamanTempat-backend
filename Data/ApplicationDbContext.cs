using Microsoft.EntityFrameworkCore;
// Sesuaikan dengan namespace yang ada di file Peminjaman.cs dan Tempat.cs
using _2026_PeminjamanTempat_backend.Entities;

namespace _2026_PeminjamanTempat_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tempat> Tempat { get; set; }
        public DbSet<Peminjaman> Peminjaman { get; set; }
    }
}