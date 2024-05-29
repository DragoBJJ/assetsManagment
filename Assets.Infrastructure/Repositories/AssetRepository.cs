
using System.Collections;
using Assets.Domain;
using Assets.Domain.Repositories;
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
            return await dbContext.Assets.Include(a=> a.Materials).FirstOrDefaultAsync(a => a.Id == id);
        }

        public List<Asset> GetAssets(Specification<Asset> specifications)
        {
            return  SpecificationQueryBuilder.GetQuery(dbContext.Assets, specifications).ToList();
        }

        public async Task SaveChanges() => await dbContext.SaveChangesAsync();  
        
    }
}