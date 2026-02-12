namespace PeminjamanTempatBackend.Entities
{
    public class Peminjaman
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Menambahkan UserId
        public int TempatId { get; set; }
        public Tempat Tempat { get; set; }
        public DateTime StartTime { get; set; }  // Menambahkan StartTime
        public DateTime EndTime { get; set; }  // Menambahkan EndTime
        public string Status { get; set; }
    }
}
