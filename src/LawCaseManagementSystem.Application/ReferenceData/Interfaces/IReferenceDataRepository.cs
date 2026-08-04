using LawCaseManagementSystem.Domain.Entities.Common;
namespace LawCaseManagementSystem.Application.ReferenceData.Interfaces;

public interface IReferenceDataRepository<TEntity> where TEntity : ReferenceDataEntity
{
    Task<List<TEntity>> GetAllAsync(bool includeInactive = false);

    Task AddAsync(TEntity entity);

    Task<TEntity?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}