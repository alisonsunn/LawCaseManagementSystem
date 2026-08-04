using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace LawCaseManagementSystem.Infrastructure.Repositories;

public class ReferenceDataRepository<TEntity> : IReferenceDataRepository<TEntity> where TEntity : ReferenceDataEntity
{
    private readonly LawFirmDbContext _dbContext;
    private readonly DbSet<TEntity> _entities;

    public ReferenceDataRepository(LawFirmDbContext dbContext)
    {
        _dbContext = dbContext;
        _entities = dbContext.Set<TEntity>();
    }

    public async Task<List<TEntity>> GetAllAsync(bool includeInactive = false)
    {
        var query = _entities.AsNoTracking();

        if (!includeInactive)
        {
            query = query.Where(entity => entity.IsActive);
        }

        return await query
            .OrderBy(entity => entity.DisplayOrder)
            .ThenBy(entity => entity.Name)
            .ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(Guid id)
    {
        return await _entities.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task AddAsync(TEntity entity)
    {
        await _entities.AddAsync(entity);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}