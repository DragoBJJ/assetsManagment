namespace Assets.Domain.Repositories
{
    public interface IMaterialRepository
    {

        Task<IEnumerable<Material>> GetAllAsync();

        Task<Asset?> GetByIDAsync(int id);

        Task<int> Create(Material entity);

        Task SaveChanges();

        Task Delete(Material entity);
    }
}
