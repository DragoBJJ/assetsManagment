namespace Assets.Domain.Repositories
{
    public interface IMaterialRepository
    {
        Task<int> Create(Material entity);

        Task DeleteAll(IEnumerable<Material> entities);
        
        Task Delete(Material entity);  

        Task SaveChanges();

    }
}
