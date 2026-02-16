namespace _2026_PeminjamanTempat_backend.Entities
{
    public class Peminjaman
    {
        public int Id { get; set; }
        public string NamaPeminjam { get; set; } = string.Empty; 

        public int TempatId { get; set; }
        public Tempat? Tempat { get; set; } 

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; } = "Pending";
    }
}