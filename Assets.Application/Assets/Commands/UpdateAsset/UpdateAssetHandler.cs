using Assets.Application.Assets.DTO;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Commands.UpdateAsset
{
    public class UpdateAssetHandler(ILogger<UpdateAssetHandler> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<UpdateAssetCommand, AssetDTO>
    {
        public async Task<AssetDTO?> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Update asset by id: {request.Id}");

            var asset = await assetRepository.GetByIDAsync(request.Id);

            if(asset is null )
            {
                return null;
            }


             mapper.Map(request, asset);
             await assetRepository.SaveChanges();

            return mapper.Map<AssetDTO>(asset);
        }
    }
}
