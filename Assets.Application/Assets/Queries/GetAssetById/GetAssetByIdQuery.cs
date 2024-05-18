using Assets.Application.Assets.DTO;
using MediatR;

namespace Assets.Application.Assets.Queries.GetAssetById
{
    public class GetAssetByIdQuery(int Id) : IRequest<AssetDTO?>
    {
        public int Id { get; } = Id;
    }
}
