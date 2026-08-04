using LawCaseManagementSystem.Domain.Entities.ReferenceData;

namespace LawCaseManagementSystem.Application.ReferenceData.Interfaces;

public interface IPracticeAreaRepository
{
    Task<List<PracticeArea>> GetPracticeAreas(bool includeInactive = false);
    Task CreatePracticeArea(PracticeArea practiceArea);
    Task<PracticeArea?> GetPracticeAreaById(Guid id);
    Task SaveChangesAsync();
}
