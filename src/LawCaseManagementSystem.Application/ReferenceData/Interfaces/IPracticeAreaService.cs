using LawCaseManagementSystem.Application.ReferenceData.DTOs;

namespace LawCaseManagementSystem.Application.ReferenceData.Services;

public interface IPracticeAreaService
{
    Task<List<ReferenceDataDto>> GetPracticeAreas();
}