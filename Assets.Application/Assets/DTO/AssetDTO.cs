
using Assets.Application.Materials.DTO;
using Assets.Domain;

namespace Assets.Application.Assets.DTO
{
    public class AssetDTO
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public AssetType Category { get; set; } = default!;
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public int Space { get; set; } = default!;
        public List<MaterialDTO> Materials { get; set; } = [];

        public  static AssetDTO? FromEntity(Asset? a)
        {
            if(a == null)
            {
                return null;
            }

            return new AssetDTO()
            {
                Category = a.Category,
                Description = a.Description,
                Name = a.Name,
                City = a.Address?.City,
                Street = a.Address?.Street,
                PostalCode = a.Address?.PostalCode,
                Materials = a.Materials.Select(MaterialDTO.FromEntity).ToList()!
               
            };

        }
    }
}
