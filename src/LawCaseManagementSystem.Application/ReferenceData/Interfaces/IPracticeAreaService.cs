using LawCaseManagementSystem.Application.ReferenceData.DTOs;

namespace LawCaseManagementSystem.Application.ReferenceData.Interfaces;

public interface IPracticeAreaService
{
    Task<List<ReferenceDataDto>> GetPracticeAreas();
}