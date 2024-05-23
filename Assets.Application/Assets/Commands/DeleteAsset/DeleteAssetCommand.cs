using MediatR;

namespace Assets.Application.Assets.Commands.DeleteAsset
{
    public class DeleteAssetCommand(int id) : IRequest
    {
        public int Id { get; } = id;
    }
}
