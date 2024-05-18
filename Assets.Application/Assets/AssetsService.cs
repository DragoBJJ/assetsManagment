using Assets.Application.Assets.DTO;
using Assets.Domain;
using Assets.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Assets.Application.Assets;

internal class AssetsService(IAssetRepository assetRepository, ILogger<AssetsService> logger, IMapper mapper) : IAssetsService
{
    public async Task<IEnumerable<AssetDTO>> GetAllAssets()
    {
        logger.LogInformation($"Getting All Assets");
        var assets = await assetRepository.GetAllAsync();

        var assetsDTO = mapper.Map<List<AssetDTO>>(assets);

        return assetsDTO!;
    }

    public async Task<AssetDTO?> GetAssetByID(int id)
    {
        logger.LogInformation($"Getting Asset by ID: {id}");
        var asset = await assetRepository.GetByIDAsync(id);

        if (asset == null)
        {
            return null;
        }

        var assetDTO = mapper.Map<AssetDTO>(asset);
        return assetDTO;

    }

    public async Task<int?> CreateAsset(CreateAssetDTO assetDto)
    {
        logger.LogInformation($"Creating a new Asset: {assetDto}");

        var asset = mapper.Map<Asset>(assetDto);

        var id = await assetRepository.Create(asset);
        return id;
    }
}
