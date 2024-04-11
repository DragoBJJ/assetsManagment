using Assets.Application.Assets.DTO;
using Assets.Domain;

namespace Assets.Application.Assets
{
    public interface IAssetsService
    {
        Task<IEnumerable<AssetDTO>> GetAllAssets();

        Task<AssetDTO?> GetAssetByID(int id);
    }
}