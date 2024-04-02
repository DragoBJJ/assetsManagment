using Assets.Domain;
using Assets.Domain.Repositories;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets;

internal class AssetsService(IAssetRepository assetRepository, ILogger<AssetsService> logger) : IAssetsService
{
    public async Task<IEnumerable<Asset>> GetAllAssets()
    {
        logger.LogInformation($"Getting All Assets");
        return await assetRepository.GetAllAsync();
    }

    public async Task<Asset?> GetAssetByID(int id)
    {
        logger.LogInformation($"Getting Asset by ID: {id}");
        return await assetRepository.GetByIDAsync(id);
    }
}
