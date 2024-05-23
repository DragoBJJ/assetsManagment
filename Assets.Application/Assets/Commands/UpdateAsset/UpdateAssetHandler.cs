using Assets.Application.Assets.DTO;
using Assets.Domain;
using Assets.Domain.Exceptions;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Commands.UpdateAsset
{
    public class UpdateAssetHandler(ILogger<UpdateAssetHandler> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<UpdateAssetCommand, AssetDTO>
    {
        public async Task<AssetDTO> Handle(UpdateAssetCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Update asset by id: {@AssetId} with {@updatedAsset}", request.Id, request);

            var asset = await assetRepository.GetByIDAsync(request.Id);

            if(asset is null )
            {
                throw new NotFoundException(nameof(Asset), request.Id.ToString());
            }


             mapper.Map(request, asset);
             await assetRepository.SaveChanges();

            return mapper.Map<AssetDTO>(asset);
        }
    }
}
