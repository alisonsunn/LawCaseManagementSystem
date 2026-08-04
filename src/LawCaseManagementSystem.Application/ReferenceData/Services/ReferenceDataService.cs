using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.Common;

namespace LawCaseManagementSystem.Application.ReferenceData.Services;

public class ReferenceDataService<TEntity>: IReferenceDataService<TEntity> where TEntity : ReferenceDataEntity, new()
{
    private readonly IReferenceDataRepository<TEntity> _repository;

    public ReferenceDataService(IReferenceDataRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public async Task<List<ReferenceDataDto>> GetAllAsync(bool includeInactive = false)
    {
        var entities = await _repository.GetAllAsync(includeInactive);

        return entities.Select(ToDto).ToList();
    }

    public async Task<ReferenceDataDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        return entity is null ? null : ToDto(entity);
    }

    public async Task<ReferenceDataDto> CreateAsync(CreateReferenceDataDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new InvalidOperationException(
                "Name is required.");
        }

        var entity = new TEntity
        {
            Id = Guid.NewGuid(),
            Name = dto.Name.Trim(),
            Code = dto.Code?.Trim(),
            DisplayOrder = dto.DisplayOrder,
            IsActive = true
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<ReferenceDataDto?> UpdateAsync(Guid id,UpdateReferenceDataDto dto)
    {
        var entity =
            await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new InvalidOperationException(
                "Name is required.");
        }

        entity.Name = dto.Name.Trim();
        entity.Code = dto.Code?.Trim();
        entity.DisplayOrder = dto.DisplayOrder;

        await _repository.SaveChangesAsync();

        return ToDto(entity);
    }

    public async Task<bool> SetActiveAsync(Guid id,bool isActive)
    {
        var entity =
            await _repository.GetByIdAsync(id);

        if (entity is null)
        {
            return false;
        }

        entity.IsActive = isActive;

        await _repository.SaveChangesAsync();

        return true;
    }

    private static ReferenceDataDto ToDto(ReferenceDataEntity entity)
    {
        return new ReferenceDataDto
        {
            Id = entity.Id,
            Name = entity.Name,
            Code = entity.Code,
            DisplayOrder = entity.DisplayOrder,
            IsActive = entity.IsActive
        };
    }
}