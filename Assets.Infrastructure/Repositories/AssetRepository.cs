
using Assets.Domain;
using Assets.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Assets.Infrastructure.Repositories
{
    internal class AssetRepository(AssetsDbContext dbContext) : IAssetRepository
    {
        public async Task<IEnumerable<Asset>> GetAllAsync()
        {
            return await dbContext.Assets.ToListAsync();
        }

        public async Task<Asset?> GetByIDAsync(int id)
        {
            return await dbContext.Assets.FirstOrDefaultAsync(a => a.Id == id); 
        }
    }
}
