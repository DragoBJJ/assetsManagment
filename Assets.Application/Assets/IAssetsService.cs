using Assets.Domain;

namespace Assets.Application.Assets
{
    public interface IAssetsService
    {
        Task<IEnumerable<Asset>> GetAllAssets();

        Task<Asset?> GetAssetByID(int id);
    }
}