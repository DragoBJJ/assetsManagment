using Assets.Application.Assets.DTO;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Queries.GetAssetById
{
    public class GetAssetByIdQueryHandler(ILogger<GetAssetByIdQueryHandler> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<GetAssetByIdQuery, AssetDTO>
    {
        public async Task<AssetDTO?> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation($"Getting Asset by ID: {request}");
            var asset = await assetRepository.GetByIDAsync(request.Id);

            if (asset == null)
            {
                return null;
            }

            var assetDTO = mapper.Map<AssetDTO>(asset);
            return assetDTO;
        }
    }
}
