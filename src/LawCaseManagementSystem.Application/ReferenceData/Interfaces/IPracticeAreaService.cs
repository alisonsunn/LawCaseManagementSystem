using LawCaseManagementSystem.Application.ReferenceData.DTOs;

namespace LawCaseManagementSystem.Application.ReferenceData.Interfaces;

public interface IPracticeAreaService
{
    Task<List<ReferenceDataDto>> GetPracticeAreas(bool includeInactive = false);
    Task<ReferenceDataDto> CreatePracticeArea(CreateReferenceDataDto createReferenceDataDto);
    Task<ReferenceDataDto?> GetPracticeAreaById(Guid id);
    Task<ReferenceDataDto?> UpdatePracticeArea(Guid id, UpdateReferenceDataDto updateReferenceDataDto);
    Task<bool> SetPracticeAreaActive(Guid id, bool isActive);
}
