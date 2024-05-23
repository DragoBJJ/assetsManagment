using Assets.Application.Assets.DTO;
using MediatR;
namespace Assets.Application.Assets.Queries.GetAllAssets
{
    public class GetAllAssetsQuery() : IRequest<IEnumerable<AssetDTO>>
    {
     
    }
}
