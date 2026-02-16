using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PeminjamanTempat_backend.Data;
using _2026_PeminjamanTempat_backend.Entities;
using _2026_PeminjamanTempat_backend.DTOs.Peminjaman;

namespace _2026_PeminjamanTempat_backend.Controllers
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

        // ==============================
        // CREATE
        // ==============================
        [HttpPost]
        public async Task<IActionResult> Create(PeminjamanCreateDto dto)
        {
            if (string.IsNullOrEmpty(dto.NamaPeminjam))
            {
                return BadRequest("Nama Peminjam wajib diisi.");
            }

            // Validasi apakah TempatId benar-benar ada
            var tempatExists = await _context.Tempat.AnyAsync(t => t.Id == dto.TempatId);
            if (!tempatExists) return BadRequest("Ruangan (Tempat) tidak ditemukan.");

            var peminjamanBaru = new Peminjaman
            {
                TempatId = dto.TempatId,
                NamaPeminjam = dto.NamaPeminjam, 
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Status = string.IsNullOrEmpty(dto.Status) ? "Pending" : dto.Status
            };

            _context.Peminjaman.Add(peminjamanBaru);
            await _context.SaveChangesAsync();

            // Me-load data tempat agar response lengkap dengan info ruangan
            await _context.Entry(peminjamanBaru).Reference(p => p.Tempat).LoadAsync();

            return CreatedAtAction(nameof(GetById), new { id = peminjamanBaru.Id }, peminjamanBaru);
        }

        // ==============================
        // GET ALL (Dengan Filter Status)
        // ==============================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> GetAll([FromQuery] string? status)
        {
            var query = _context.Peminjaman
                .Include(p => p.Tempat)
                .AsNoTracking() // Lebih cepat untuk pengambilan data saja
                .AsQueryable();

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(p => p.Status.ToLower() == status.ToLower());
            }

            var data = await query.ToListAsync();
            return Ok(data);
        }

        // ==============================
        // GET BY ID
        // ==============================
        [HttpGet("{id:int}")] 
        public async Task<ActionResult<Peminjaman>> GetById(int id)
        {
            var peminjaman = await _context.Peminjaman
                .Include(p => p.Tempat)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (peminjaman == null)
                return NotFound("Data peminjaman tidak ditemukan");

            return Ok(peminjaman);
        }

        // ==============================
        // UPDATE (Edit Data Lengkap)
        // ==============================
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PeminjamanCreateDto dto)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);

            if (peminjaman == null)
                return NotFound("Data tidak ditemukan");

            // Periksa jika TempatId diganti, apakah tempat baru ada?
            if (peminjaman.TempatId != dto.TempatId)
            {
                var tempatExists = await _context.Tempat.AnyAsync(t => t.Id == dto.TempatId);
                if (!tempatExists) return BadRequest("Ruangan baru tidak valid.");
            }

            peminjaman.TempatId = dto.TempatId;
            peminjaman.NamaPeminjam = dto.NamaPeminjam;
            peminjaman.StartTime = dto.StartTime;
            peminjaman.EndTime = dto.EndTime;
            
            if (!string.IsNullOrEmpty(dto.Status))
            {
                peminjaman.Status = dto.Status;
            }
            
            try 
            {
                await _context.SaveChangesAsync();
                return Ok(peminjaman);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Terjadi kesalahan saat memperbarui data.");
            }
        }

        // ==============================
        // UPDATE STATUS ONLY
        // ==============================
        [HttpPut("status/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, [FromBody] PeminjamanStatusUpdateDto dto)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);

            if (peminjaman == null)
                return NotFound("Data tidak ditemukan");

            peminjaman.Status = dto.Status;
            await _context.SaveChangesAsync();

            return Ok(peminjaman);
        }

        // ==============================
        // DELETE
        // ==============================
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var peminjaman = await _context.Peminjaman.FindAsync(id);

            if (peminjaman == null)
                return NotFound("Data tidak ditemukan");

            _context.Peminjaman.Remove(peminjaman);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Data peminjaman berhasil dihapus" });
        }
        
        // ==============================
        // GET BY STATUS (Tambahan untuk mobilitas)
        // ==============================
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> GetByStatus(string status)
        {
            var data = await _context.Peminjaman
                .Include(p => p.Tempat)
                .Where(p => p.Status.ToLower() == status.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return Ok(data);
        }
    }
}