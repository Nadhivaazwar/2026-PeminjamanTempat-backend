using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeminjamanTempatBackend.Data;
using PeminjamanTempatBackend.Entities;
using PeminjamanTempatBackend.DTOs.Tempat;

namespace PeminjamanTempatBackend.Controllers
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

        // Ambil semua tempat yang belum di-soft delete
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TempatResponseDto>>> GetTempat()
        {
            return await _context.Tempat
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

        // Tambah Tempat Baru
        [HttpPost]
        public async Task<ActionResult<Tempat>> CreateTempat(TempatCreateDto dto)
        {
            var tempat = new Tempat
            {
                Name = dto.Name,
                Location = dto.Location,
                Capacity = dto.Capacity,
                Status = dto.Status ?? "Tersedia",
                Description = dto.Description
            };

            _context.Tempat.Add(tempat);
            await _context.SaveChangesAsync();
            return Ok(tempat);
        }

        // Update Data Tempat
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTempat(int id, TempatUpdateDto dto)
        {
            if (id != dto.Id) return BadRequest();

            var tempat = await _context.Tempat.FindAsync(id);
            if (tempat == null) return NotFound();

            tempat.Name = dto.Name;
            tempat.Location = dto.Location;
            tempat.Capacity = dto.Capacity;
            tempat.Status = dto.Status;
            tempat.Description = dto.Description;

            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTempat(int id)
        {
            var tempat = await _context.Tempat.FindAsync(id);
            if (tempat == null) return NotFound();
            
            _context.Tempat.Remove(tempat);

            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}