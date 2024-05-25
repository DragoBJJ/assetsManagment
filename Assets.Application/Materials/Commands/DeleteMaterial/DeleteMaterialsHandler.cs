using Assets.Domain.Exceptions;
using Assets.Domain;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Materials.Commands.DeleteMaterial
{
    public  class DeleteMaterialsHandler(ILogger<DeleteMaterialsHandler> logger,
        IAssetRepository assetRepository,
          IMaterialRepository materialRepository) : IRequestHandler<DeleteMaterialsCommand>
    {

        public async Task Handle(DeleteMaterialsCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting all materials for Asset: {@AssetId}", request.AssetId);

            var asset = await assetRepository.GetByIDAsync(request.AssetId) ?? throw new NotFoundException(nameof(Asset), request.AssetId.ToString());

            await materialRepository.DeleteAll(asset.Materials);

        }
    }
}
