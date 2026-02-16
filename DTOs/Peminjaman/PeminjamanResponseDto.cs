namespace PeminjamanTempatBackend.DTOs.Peminjaman
{
    public class PeminjamanResponseDto
    {
        public int Id { get; set; }
        public int TempatId { get; set; }
        public string NamaPeminjam { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = string.Empty;
        public string TempatName { get; set; } = string.Empty;
    }
}
