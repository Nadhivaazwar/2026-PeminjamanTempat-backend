namespace PeminjamanTempatBackend.DTOs.Peminjaman
{
    public class PeminjamanCreateDto
    {
        public int TempatId { get; set; }
        public int UserId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        // Status biasanya default "Pending" di Backend, tapi boleh diinput jika perlu
        public string Status { get; set; } = "Pending"; 
    }
}