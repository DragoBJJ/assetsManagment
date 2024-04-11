using Assets.Application.Assets.DTO;
namespace Assets.Application.Assets
{
    public interface IAssetsService
    {
        Task<IEnumerable<AssetDTO>> GetAllAssets();

        Task<AssetDTO?> GetAssetByID(int id);

        Task<int> CreateAsset(CreateAssetDTO assetDto);
    }
}