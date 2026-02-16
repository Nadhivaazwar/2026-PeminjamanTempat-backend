using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using _2026_PeminjamanTempat_backend.Data;
using _2026_PeminjamanTempat_backend.Entities;
using _2026_PeminjamanTempat_backend.DTOs.Tempat;

namespace _2026_PeminjamanTempat_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TempatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TempatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ==============================
        // GET ALL
        // ==============================
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TempatResponseDto>>> GetTempat()
        {
            // Menggunakan AsNoTracking untuk efisiensi pengambilan data read-only
            return await _context.Tempat
                .AsNoTracking()
                .Where(t => t.DeletedAt == null)
                .Select(t => new TempatResponseDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    Location = t.Location,
                    Capacity = t.Capacity,
                    Status = t.Status,
                    Description = t.Description
                }).ToListAsync();
        }

        // ==============================
        // GET BY ID 
        // ==============================
        [HttpGet("{id:int}")] // Tambahkan :int untuk validasi tipe data di rute
        public async Task<ActionResult<Tempat>> GetById(int id)
        {
            try 
            {
                // Gunakan FindAsync atau FirstOrDefaultAsync
                var tempat = await _context.Tempat.FindAsync(id);

                if (tempat == null || tempat.DeletedAt != null)
                {
                    // Mengembalikan objek JSON agar frontend lebih mudah memproses pesan error
                    return NotFound(new { message = $"Ruangan dengan ID {id} tidak ditemukan" });
                }

                return Ok(tempat);
            }
            catch (Exception ex)
            {
                // Menangkap error database jika nama tabel atau koneksi bermasalah
                return StatusCode(500, new { message = "Kesalahan server: " + ex.Message });
            }
        }

        // ==============================
        // CREATE
        // ==============================
        [HttpPost]
        public async Task<ActionResult<Tempat>> CreateTempat(TempatCreateDto dto)
        {
            var tempat = new Tempat
            {
                Name = dto.Name,
                Location = dto.Location,
                Capacity = dto.Capacity,
                Status = string.IsNullOrEmpty(dto.Status) ? "Tersedia" : dto.Status,
                Description = dto.Description
            };

            _context.Tempat.Add(tempat);
            await _context.SaveChangesAsync();
            
            // Standar REST: Mengembalikan CreatedAtAction agar frontend tahu lokasi resource baru
            return CreatedAtAction(nameof(GetById), new { id = tempat.Id }, tempat);
        }

        // ==============================
        // UPDATE (PUT)
        // ==============================
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTempat(int id, [FromBody] TempatUpdateDto dto)
        {
            try 
            {
                var tempat = await _context.Tempat.FindAsync(id);
                if (tempat == null) return NotFound(new { message = "Data tidak ditemukan" });

                // Update field satu per satu
                tempat.Name = dto.Name;
                tempat.Location = dto.Location;
                tempat.Capacity = dto.Capacity;
                
                if (!string.IsNullOrEmpty(dto.Status)) {
                    tempat.Status = dto.Status;
                }
                
                tempat.Description = dto.Description;

                await _context.SaveChangesAsync();
                
                // Kembalikan objek yang diperbarui agar frontend bisa langsung update state
                return Ok(tempat);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, new { message = "Data sedang digunakan atau telah berubah" });
            }
        }

        // ==============================
        // DELETE
        // ==============================
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTempat(int id)
        {
            var tempat = await _context.Tempat.FindAsync(id);
            if (tempat == null) return NotFound(new { message = "Data tidak ditemukan" });
            
            _context.Tempat.Remove(tempat);
            await _context.SaveChangesAsync();
            
            return Ok(new { message = "Data ruangan berhasil dihapus" });
        }
    }
}