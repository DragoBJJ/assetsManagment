using Assets.Domain;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Commands.CreateAsset
{
    public class CreateAssetHandler(ILogger<CreateAssetHandler> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<CreateAssetCommand, int>
    {
        public async Task<int> Handle(CreateAssetCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating a new Asset: {@Asset}",request);

            var asset = mapper.Map<Asset>(request);

            var id = await assetRepository.Create(asset);
            return id;
        }
    }
}
