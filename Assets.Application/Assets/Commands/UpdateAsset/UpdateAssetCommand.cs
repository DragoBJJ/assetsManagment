using Assets.Application.Assets.DTO;
using MediatR;


namespace Assets.Application.Assets.Commands.UpdateAsset
{
    public class UpdateAssetCommand(): IRequest<AssetDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Space { get; set; } = default!;
    }
}
