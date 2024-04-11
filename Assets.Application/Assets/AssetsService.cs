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

        var assetsDTO = assets.Select(AssetDTO.FromEntity);

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

        var assetDTO = AssetDTO.FromEntity(asset);
        return assetDTO;

    }

    public Task<int>? CreateAsset(CreateAssetDTO assetDto)
    {
        logger.LogInformation($"Creating a new Asset: {assetDto}");

        var asset = CreateAssetDTO.FromCreateAssetDto(assetDto);

        if (asset == null)
        {
            return null;
        }

         var assetID = assetRepository.Create(asset);
        return assetID; 
    }


}
