using Assets.Domain;
using Assets.Domain.Exceptions;
using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets.Commands.DeleteAsset
{
    public class DeleteAssetHandler(ILogger<DeleteAssetCommand> logger, IMapper mapper, IAssetRepository assetRepository) : IRequestHandler<DeleteAssetCommand>
    {
        public async Task Handle(DeleteAssetCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting asset with id: {@AssetId}",request.Id);

            var asset = await assetRepository.GetByIDAsync(request.Id) ?? throw new NotFoundException(nameof(Asset), request.Id.ToString());
            await assetRepository.Delete(asset);
        }
    }
}
