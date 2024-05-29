using Assets.Domain;
using Assets.Domain.Repositories;
using Assets.Domain.Specifications;
using Assets.Infrastructure.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Assets.Infrastructure.Repositories
{
    internal class AssetRepository(AssetsDbContext dbContext) : IAssetRepository
    {
        public async Task<int> Create(Asset entity)
        {
            dbContext.Assets.Add(entity);
            await dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task Delete(Asset entity)
        {
            dbContext.Assets.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await dbContext.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIDAsync(int id)
        {
            return await ApplySpecification(new AssetByIdSpecification(id)).FirstOrDefaultAsync();
        }

        private IQueryable<Asset> ApplySpecification(Specification<Asset> specification)
        {
            return SpecificEvaluator.GetQuery(dbContext.Set<Asset>(), specification);
        }


        public async Task<List<Asset>> GetByCategory(string name)
        {
            return await ApplySpecification(new AssetByCategorySpecification(name)).ToListAsync();
        }

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();  
        
    }
}