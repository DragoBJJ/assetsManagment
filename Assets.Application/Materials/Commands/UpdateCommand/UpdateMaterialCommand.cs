using Assets.Application.Materials.DTO;
using MediatR;

namespace Assets.Application.Materials.Commands.UpdateCommand
{
    public class UpdateMaterialCommand(): IRequest<MaterialDTO>
    {
        public int AssetId { get; set;}
        public int MaterialId { get; set;}
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string Origin { get; set; } = default!;
    }
}
