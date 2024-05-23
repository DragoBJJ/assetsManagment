using Assets.Domain;
using Assets.Domain.Repositories;

namespace Assets.Infrastructure.Repositories
{
    internal class MaterialRepository(AssetsDbContext dbContext) : IMaterialRepository
    {
        public async Task<int> Create(Material entity)
        {
            dbContext.Materials.Add(entity);
            await dbContext.SaveChangesAsync();  
            return entity.Id;
        }

        public Task Delete(Material entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Material>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Asset?> GetByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
