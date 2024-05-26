using Assets.Application.Materials.DTO;
using Assets.Domain;
using Assets.Domain.Exceptions;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Materials.Queries
{
    public class GetMaterialByIdForAssetHandler(
        ILogger<GetMaterialByIdForAssetHandler> logger,
        IMapper mapper,
        IAssetRepository assetRepository) : IRequestHandler<GetMaterialByIdForAssetQuery, MaterialDTO>
    {
        public async Task<MaterialDTO> Handle(GetMaterialByIdForAssetQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retriving material by ID: {@materialId} for asset with id : {@AssetID}", request.materialId, request.assetID);

            var asset = await assetRepository.GetByIDAsync(request.assetID) ?? throw new NotFoundException(nameof(Asset), request.assetID.ToString());

            var material = asset.Materials.FirstOrDefault(m => m.Id == request.materialId) ?? throw new NotFoundException(nameof(Material), request.materialId.ToString());

            var materialDto = mapper.Map<MaterialDTO>(material);

            return materialDto;
        }
    }
}
