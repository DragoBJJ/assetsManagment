

namespace Assets.Application.Assets.DTO
{
    public class CreateAssetDTO
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public int Space { get; set; } = default!;

        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        }
    }
