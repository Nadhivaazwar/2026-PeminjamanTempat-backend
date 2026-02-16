namespace _2026_PeminjamanTempat_backend.DTOs.Tempat
{
    public class TempatCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Description { get; set; } // Tetap pakai ? karena boleh null
    }
}