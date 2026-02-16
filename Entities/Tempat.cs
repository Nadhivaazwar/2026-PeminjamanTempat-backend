using System;
using System.ComponentModel.DataAnnotations;
namespace _2026_PeminjamanTempat_backend.Entities
{
    public class Tempat
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Location { get; set; } = string.Empty;
        [Required]
        public string Status { get; set; } = "Tersedia";
        public string? Description { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int Capacity { get; set; }
    }
}
