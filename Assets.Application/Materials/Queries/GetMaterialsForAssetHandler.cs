using Assets.Application.Materials.DTO;
using Assets.Domain;
using Assets.Domain.Exceptions;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Materials.Queries
{
    public class GetMaterialsForAssetHandler(
        ILogger<GetMaterialsForAssetHandler> logger,
        IMapper mapper,
        IAssetRepository assetRepository) : IRequestHandler<GetMaterialsForAssetQuery, IEnumerable<MaterialDTO>>
    {
        public async Task<IEnumerable<MaterialDTO>> Handle(GetMaterialsForAssetQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retriving materials for asset with id : {@AssetID}", request.AssetId);

            var asset = await assetRepository.GetByIDAsync(request.AssetId) ?? throw new NotFoundException(nameof(Asset), request.AssetId.ToString());

            var materialsDto = mapper.Map<IEnumerable<MaterialDTO>>(asset.Materials);

            return materialsDto;
        }

    }
}
