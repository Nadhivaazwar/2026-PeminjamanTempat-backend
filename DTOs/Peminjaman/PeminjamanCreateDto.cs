namespace _2026_PeminjamanTempat_backend.DTOs.Peminjaman
{
    public class PeminjamanCreateDto
    {
        public int TempatId { get; set; }
        public string NamaPeminjam { get; set; } = string.Empty; 
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
