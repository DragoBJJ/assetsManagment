﻿namespace Assets.Domain.Repositories;

public interface IAssetRepository
{
    Task<IEnumerable<Asset>> GetAllAsync();

    Task<Asset?> GetByIDAsync(int id);
}
    
