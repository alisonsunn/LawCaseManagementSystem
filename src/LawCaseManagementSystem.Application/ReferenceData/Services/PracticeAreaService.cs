using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;

namespace LawCaseManagementSystem.Application.ReferenceData.Services;

public class PracticeAreaService : IPracticeAreaService
{
    private readonly IPracticeAreaRepository _repository;

    public PracticeAreaService(IPracticeAreaRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ReferenceDataDto>> GetPracticeAreas()
    {
        var practiceAreas = await _repository.GetPracticeAreas();
        return practiceAreas
            .Select(practiceArea => new ReferenceDataDto
            {
                Id = practiceArea.Id,
                Name = practiceArea.Name,
                Code = practiceArea.Code,
                DisplayOrder = practiceArea.DisplayOrder,
                IsActive = practiceArea.IsActive
            }).ToList();
    }
}
