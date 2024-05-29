using Assets.Application.Assets.DTO;
using MediatR;

namespace Assets.Application.Materials.Queries.GetByCategory;

public class GetByCategoryQuery(string category): IRequest<List<AssetDTO>>
{
    public string Category { get; } = category;
}
