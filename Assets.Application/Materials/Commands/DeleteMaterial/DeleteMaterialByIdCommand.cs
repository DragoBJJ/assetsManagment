using MediatR;

namespace Assets.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteMaterialByIdCommand(int assetId, int materialId): IRequest
    {
        public int AssetId { get; } = assetId;
        public int MaterialId { get; } = materialId;    
    }
}
