using Assets.Application.Materials.DTO;
using MediatR;

namespace Assets.Application.Materials.Queries
{
    public class GetMaterialsForAssetQuery(int assetId): IRequest<IEnumerable<MaterialDTO>>
    {
        public int AssetId { get; } = assetId;
    }
}
