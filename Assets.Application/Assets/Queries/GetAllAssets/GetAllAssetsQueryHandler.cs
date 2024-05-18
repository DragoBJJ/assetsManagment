using Assets.Application.Assets.DTO;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Queries.GetAllAssets
{
    public class GetAllAssetsQueryHandler(ILogger<GetAllAssetsQueryHandler> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<GetAllAssetsQuery, IEnumerable<AssetDTO>>
    {
        public async Task<IEnumerable<AssetDTO>> Handle(GetAllAssetsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting All Assets");
            var assets = await assetRepository.GetAllAsync();
            var assetsDTO = mapper.Map<IEnumerable<AssetDTO>>(assets);
            return assetsDTO;
        }
    }
}
