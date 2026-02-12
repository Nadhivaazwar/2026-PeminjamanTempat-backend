using Microsoft.EntityFrameworkCore;
using PeminjamanTempatBackend.Entities;

namespace PeminjamanTempatBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Tempat> Tempat { get; set; }
        public DbSet<Peminjaman> Peminjaman { get; set; }
    }
}