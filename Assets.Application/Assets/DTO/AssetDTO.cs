using Assets.Application.Materials.DTO;
namespace Assets.Application.Assets.DTO
{
    public class AssetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public int Space { get; set; } = default!;
        public List<MaterialDTO> Materials { get; set; } = [];
    }
}
