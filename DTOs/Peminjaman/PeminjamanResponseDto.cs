namespace PeminjamanTempatBackend.DTOs.Peminjaman
{
    public class PeminjamanResponseDto
    {
        public int Id { get; set; }
        public int TempatId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }
        public string TempatName { get; set; }
    }
}
