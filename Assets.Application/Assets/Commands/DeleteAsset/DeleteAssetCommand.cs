using MediatR;

namespace Assets.Application.Assets.Commands.DeleteAsset
{
    public class DeleteAssetCommand(int id) : IRequest<bool>
    {
        public int Id { get; } = id;
    }
}
