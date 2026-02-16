namespace _2026_PeminjamanTempat_backend.DTOs.Tempat
{
    public class TempatResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}