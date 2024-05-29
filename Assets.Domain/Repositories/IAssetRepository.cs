using Assets.Infrastructure.Specifications;

namespace Assets.Domain.Repositories;


public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetAllAsync();

    Task<Asset?> GetByIDAsync(int id);

    List<Asset> GetAssets(Specification<Asset> specification);

     Task<int> Create(Asset entity);

    Task SaveChanges();

    Task Delete(Asset entity);
}
    
