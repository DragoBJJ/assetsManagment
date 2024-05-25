namespace Assets.Domain.Repositories
{
    public interface IMaterialRepository
    {
        Task<int> Create(Material entity);


    }
}
