namespace PeminjamanTempatBackend.DTOs.Tempat
{
    public class TempatUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
    }
}
