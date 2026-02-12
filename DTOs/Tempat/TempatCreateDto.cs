namespace PeminjamanTempatBackend.DTOs.Tempat
{
    public class TempatCreateDto
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public string? Description { get; set; }
    }
}
