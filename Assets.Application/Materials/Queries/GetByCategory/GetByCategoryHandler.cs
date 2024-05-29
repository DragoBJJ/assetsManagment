using Assets.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Assets.Application.Assets.DTO;

namespace Assets.Application.Materials.Queries.GetByCategory
{

    public class GetByCategoryHandler(
        ILogger<GetByCategoryHandler> logger,
        IMapper mapper,
        IAssetRepository assetRepository) : IRequestHandler<GetByCategoryQuery, List<AssetDTO>>
    {
        public async Task<List<AssetDTO>> Handle(GetByCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Retriving Assets by category: ${@category}", request.Category);

            var assets = await assetRepository.GetByCategory(request.Category);  

            var materialDto = mapper.Map<List<AssetDTO>>(assets);

            return materialDto;
        }
    }
}

