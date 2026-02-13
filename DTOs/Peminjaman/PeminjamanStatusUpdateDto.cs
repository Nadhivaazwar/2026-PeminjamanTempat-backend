using System.ComponentModel.DataAnnotations;

namespace PeminjamanTempatBackend.DTOs.Peminjaman
{
    public class PeminjamanStatusUpdateDto
    {
        [Required]
        public string Status { get; set; }
    }
}