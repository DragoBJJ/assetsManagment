using Assets.Application.Assets.DTO;
using Assets.Domain;
using Assets.Domain.Exceptions;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Queries.GetAssetById
{
    public class GetAssetByIdQueryHandler(ILogger<GetAssetByIdQueryHandler> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<GetAssetByIdQuery, AssetDTO>
    {
        public async Task<AssetDTO> Handle(GetAssetByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting Asset by ID: {@requestId}", request.Id);
            var asset = await assetRepository.GetByIDAsync(request.Id) ?? throw new NotFoundException(nameof(Asset), request.Id.ToString());
            var assetDTO = mapper.Map<AssetDTO>(asset);
            return assetDTO;
        }
    }
}
