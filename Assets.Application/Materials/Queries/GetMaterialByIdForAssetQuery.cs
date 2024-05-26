using Assets.Application.Materials.DTO;
using MediatR;

namespace Assets.Application.Materials.Queries
{
    public class GetMaterialByIdForAssetQuery(int assetId, int materialId): IRequest<MaterialDTO>
    {
        public int assetID { get;  } = assetId;
        public int materialId { get; } = materialId;
    }
}
