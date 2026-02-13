using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeminjamanTempatBackend.Data;
using PeminjamanTempatBackend.Entities;
using PeminjamanTempatBackend.DTOs.Peminjaman;

namespace PeminjamanTempatBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PeminjamanController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Tambah Peminjaman
        [HttpPost]
        public async Task<ActionResult<Peminjaman>> Create(PeminjamanCreateDto dto)
        {
            var peminjaman = new Peminjaman
            {
                TempatId = dto.TempatId,
                UserId = dto.UserId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = "Pending" // Default status
            };

            _context.Peminjaman.Add(peminjaman);
            await _context.SaveChangesAsync();
            return Ok(peminjaman);
        }

        // 2. Lihat Daftar Peminjaman (Riwayat & Penelusuran)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeminjamanResponseDto>>> GetAll()
        {
            return await _context.Peminjaman
                .Include(p => p.Tempat) // Join dengan tabel Tempat
                .Select(p => new PeminjamanResponseDto
                {
                    Id = p.Id,
                    TempatId = p.TempatId,
                    UserId = p.UserId,
                    StartTime = p.StartTime,
                    EndTime = p.EndTime,
                    Status = p.Status,
                    TempatName = p.Tempat.Name
                }).ToListAsync();
        }

        // 3. Update Status (Menggunakan DTO yang baru dibuat)
        [HttpPatch("{id}/status")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] PeminjamanStatusUpdateDto dto)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);
            if (peminjaman == null) return NotFound();

            // Mengambil status dari property DTO
            peminjaman.Status = dto.Status;

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}