using Assets.Application.Assets.Commands.CreateAsset;
using Assets.Domain.Exceptions;
using Assets.Domain;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Materials.Commands.CreateMaterial
{
    public class CreateMaterialHandler(ILogger<CreateAssetHandler> logger,
        IMapper mapper,
        IAssetRepository assetRepository, 
        IMaterialRepository materialRepository) : IRequestHandler<CreateMaterialCommand>
    {
        public async Task Handle(CreateMaterialCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new material: {@MaterialRequest}", request);

            var asset = await assetRepository.GetByIDAsync(request.AssetId) ?? throw new NotFoundException(nameof(Asset), request.AssetId.ToString());

            var materialEntity = mapper.Map<Material>(request);
            await materialRepository.Create(materialEntity);    

        
        }
    }
}
