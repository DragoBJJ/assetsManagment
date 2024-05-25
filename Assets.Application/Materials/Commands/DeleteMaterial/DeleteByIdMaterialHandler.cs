using Assets.Domain.Exceptions;
using Assets.Domain;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Materials.Commands.DeleteMaterial
{
    public class DeleteByIdMaterialHandler(
        ILogger<DeleteByIdMaterialHandler> logger,
        IAssetRepository assetRepository,
        IMaterialRepository materialRepository): IRequestHandler<DeleteMaterialByIdCommand>
    {

        public async Task Handle(DeleteMaterialByIdCommand request, CancellationToken cancellationToken)
        {
             logger.LogInformation("Deleting material by id: {@materialId} for Asset by Id: {@AssetId}",request.MaterialId, request.AssetId);

             var asset = await assetRepository.GetByIDAsync(request.AssetId) ?? throw new NotFoundException(nameof(Asset), request.AssetId.ToString());

             var material = asset.Materials.FirstOrDefault(m=> m.Id == request.MaterialId) ?? throw new NotFoundException(nameof(Material), request.MaterialId.ToString());

             await materialRepository.Delete(material);
        }
    }
}
