using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeminjamanTempatBackend.Data;
using PeminjamanTempatBackend.Entities;  // Pastikan nama entitas Tempat ada di Entities
using PeminjamanTempatBackend.DTOs.Tempat;  // Pastikan sudah ada DTO untuk Tempat

namespace PeminjamanTempatBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  // Route untuk controller
    public class TempatController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        // Constructor
        public TempatController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/tempat
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tempat = await _context.Tempat.ToListAsync(); // Ambil semua data Tempat
            return Ok(tempat);
        }

        // GET: api/tempat/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var tempat = await _context.Tempat.FindAsync(id);
            if (tempat == null)
                return NotFound();

            return Ok(tempat);
        }

        // POST: api/tempat
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TempatCreateDto dto)  // DTO untuk inputan data
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tempat = new Tempat
            {
                Name = dto.Name,
                Location = dto.Location,
                Capacity = dto.Capacity,
                Status = dto.Status,
                Description = dto.Description
            };

            _context.Tempat.Add(tempat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = tempat.Id }, tempat);
        }

        // PUT: api/tempat/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TempatUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var tempat = await _context.Tempat.FindAsync(id);
            if (tempat == null)
                return NotFound();

            tempat.Name = dto.Name;
            tempat.Location = dto.Location;
            tempat.Capacity = dto.Capacity;
            tempat.Status = dto.Status;
            tempat.Description = dto.Description;

            _context.Entry(tempat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/tempat/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var tempat = await _context.Tempat.FindAsync(id);
            if (tempat == null)
                return NotFound();

            // Soft delete logic
            tempat.DeletedAt = DateTime.UtcNow;  // Soft delete
            _context.Entry(tempat).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
