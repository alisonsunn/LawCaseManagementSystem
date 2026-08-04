using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Domain.Entities.Common;
namespace LawCaseManagementSystem.Application.ReferenceData.Interfaces;

public interface IReferenceDataService<TEntity> where TEntity : ReferenceDataEntity
{
    Task<List<ReferenceDataDto>> GetAllAsync(bool includeInactive = false);
    Task<ReferenceDataDto> CreateAsync(CreateReferenceDataDto createReferenceDataDto);
    Task<ReferenceDataDto?> GetByIdAsync(Guid id);
    Task<ReferenceDataDto?> UpdateAsync(Guid id, UpdateReferenceDataDto updateReferenceDataDto);
    Task<bool> SetActiveAsync(Guid id, bool isActive);
}
