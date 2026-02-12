using System.ComponentModel.DataAnnotations;  // Tambahkan ini

namespace PeminjamanTempatBackend.Entities
{
    public class Tempat
    {
        public int Id { get; set; }

        [Required]  // Menandakan bahwa Name tidak boleh null
        public string Name { get; set; }

        [Required]  // Menandakan bahwa Location tidak boleh null
        public string Location { get; set; }

        public int Capacity { get; set; }

        [Required]  // Menandakan bahwa Status tidak boleh null
        public string Status { get; set; } = "available";  // Nilai default

        public string? Description { get; set; }

        public DateTime? DeletedAt { get; set; }  // Untuk soft delete
    }
}
