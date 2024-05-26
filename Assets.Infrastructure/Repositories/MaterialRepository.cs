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

        public async Task DeleteAll(IEnumerable<Material> entities)
        {
            dbContext.Materials.RemoveRange(entities);
            await SaveChanges();
        }

        public async Task Delete(Material entity)
        {
            dbContext.Materials.Remove(entity);
            await SaveChanges();    
        }

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();
        
    }
}
