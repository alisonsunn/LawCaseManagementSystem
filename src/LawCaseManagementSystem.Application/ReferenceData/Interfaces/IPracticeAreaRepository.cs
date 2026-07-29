using LawCaseManagementSystem.Domain.Entities.ReferenceData;

namespace LawCaseManagementSystem.Application.ReferenceData;

public interface IPracticeAreaRepository
{
    Task<List<PracticeArea>> GetPracticeAreas();
}
