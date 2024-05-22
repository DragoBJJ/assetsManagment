
using Assets.Application.Assets.Commands.CreateAsset;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Commands.DeleteAsset
{
    public class DeleteAssetHandler(ILogger<DeleteAssetCommand> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<DeleteAssetCommand, bool>
    {
        public  async Task<bool> Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting asset with id: {@AssetId}",request.Id);

            var asset = await assetRepository.GetByIDAsync(request.Id);

            if(asset is null)
            {
                return false;
            }

            await assetRepository.Delete(asset);
            return true;
        }
    }
}
