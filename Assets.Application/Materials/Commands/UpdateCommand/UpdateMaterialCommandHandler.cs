
using Assets.Application.Materials.Commands.CreateMaterial;
using Assets.Application.Materials.Commands.DeleteMaterial;
using Assets.Application.Materials.DTO;
using Assets.Domain.Exceptions;
using Assets.Domain;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Materials.Commands.UpdateCommand
{
    public class UpdateMaterialCommandHandler(ILogger<UpdateMaterialCommandHandler> logger,
        IMapper mapper,
        IAssetRepository assetRepository,
        IMaterialRepository materialRepository): IRequestHandler<UpdateMaterialCommand,  MaterialDTO>
    {

        public async Task<MaterialDTO> Handle(UpdateMaterialCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating material with Id: {@materialId} for asset with Id: {@assetID}", request.MaterialId, request.AssetId);

            var asset = await assetRepository.GetByIDAsync(request.AssetId) ?? throw new NotFoundException(nameof(Asset), request.AssetId.ToString());

            var material = asset.Materials.FirstOrDefault(m=> m.Id == request.MaterialId);

            var newMaterial = mapper.Map(request, material);
            
            await materialRepository.SaveChanges();

            var newMaterialDto = mapper.Map<MaterialDTO>(newMaterial);

            return newMaterialDto;
        }
    }
}
