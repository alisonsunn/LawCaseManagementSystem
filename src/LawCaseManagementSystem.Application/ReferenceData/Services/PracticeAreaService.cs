using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;

namespace LawCaseManagementSystem.Application.ReferenceData.Services;

public class PracticeAreaService : IPracticeAreaService
{
    private readonly IPracticeAreaRepository _repository;

    public PracticeAreaService(IPracticeAreaRepository repository)
    {
        _repository = repository;
    }

    private ReferenceDataDto ToDto(PracticeArea practiceArea)
    {
        return new ReferenceDataDto
        {
            Id = practiceArea.Id,
            Name = practiceArea.Name,
            Code = practiceArea.Code,
            DisplayOrder = practiceArea.DisplayOrder,
            IsActive = practiceArea.IsActive
        };
    }

    public async Task<List<ReferenceDataDto>> GetPracticeAreas(
        bool includeInactive = false)
    {
        var practiceAreas = await _repository.GetPracticeAreas(includeInactive);

        return practiceAreas.Select(ToDto).ToList();
    }

    public async Task<ReferenceDataDto> CreatePracticeArea(CreateReferenceDataDto createReferenceDataDto)
    {
        if (string.IsNullOrWhiteSpace(createReferenceDataDto.Name))
        {
            throw new InvalidOperationException("Name is required.");
        }

        var name = createReferenceDataDto.Name.Trim();

        var newPracticeArea = new PracticeArea
        {
            Id = Guid.NewGuid(),
            Name = name,
            Code = createReferenceDataDto.Code?.Trim(),
            DisplayOrder = createReferenceDataDto.DisplayOrder,
            IsActive = true
        };

        await _repository.CreatePracticeArea(newPracticeArea);

        return ToDto(newPracticeArea);
    }

    public async Task<ReferenceDataDto?> GetPracticeAreaById(Guid id)
    {
        var result = await _repository.GetPracticeAreaById(id);
        if (result is null)
        {
            return null;
        }
        return ToDto(result);
    }

    public async Task<ReferenceDataDto?> UpdatePracticeArea(Guid id, UpdateReferenceDataDto updateReferenceDataDto)
    {
        var practiceArea = await _repository.GetPracticeAreaById(id);
        if (practiceArea is null)
        {
            return null;
        }

        if (string.IsNullOrWhiteSpace(updateReferenceDataDto.Name))
        {
            throw new InvalidOperationException("Name is required.");
        }

        var name = updateReferenceDataDto.Name.Trim();

        practiceArea.Name = name;
        practiceArea.Code = updateReferenceDataDto.Code?.Trim();
        practiceArea.DisplayOrder = updateReferenceDataDto.DisplayOrder;

        await _repository.SaveChangesAsync();

        return ToDto(practiceArea);
    }

    public async Task<bool> SetPracticeAreaActive(Guid id, bool isActive)
    {
        var practiceArea = await _repository.GetPracticeAreaById(id);
        if (practiceArea is null)
        {
            return false;
        }

        practiceArea.IsActive = isActive;
        await _repository.SaveChangesAsync();

        return true;
    }
}
