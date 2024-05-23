using MediatR;

namespace Assets.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialCommand: IRequest
    {
        public int AssetId { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; }

        public string? Origin { get; set; }
    }
}
