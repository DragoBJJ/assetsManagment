using MediatR;

namespace Assets.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialsCommand(int assetId): IRequest
    {
        public int AssetId { get; } = assetId; 
    }
}
