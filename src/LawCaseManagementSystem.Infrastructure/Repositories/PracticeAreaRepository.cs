using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.EntityFrameworkCore;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;

namespace LawCaseManagementSystem.Infrastructure.Repositories;

public class PracticeAreaRepository : IPracticeAreaRepository
{
    private readonly LawFirmDbContext _dbContext;

    public PracticeAreaRepository(LawFirmDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<PracticeArea>> GetPracticeAreas(
        bool includeInactive = false)
    {

        if (!includeInactive)
        {
            var result = _dbContext.PracticeAreas.Where(practiceArea => practiceArea.IsActive);
        }

        return await _dbContext.PracticeAreas
            .OrderBy(practiceArea => practiceArea.DisplayOrder)
            .ThenBy(practiceArea => practiceArea.Name)
            .ToListAsync();
    }

    public async Task CreatePracticeArea(PracticeArea practiceArea)
    {
        await _dbContext.PracticeAreas.AddAsync(practiceArea);
        await SaveChangesAsync();
    }

    public async Task<PracticeArea?> GetPracticeAreaById(Guid id)
    {
        return await _dbContext.PracticeAreas
            .FirstOrDefaultAsync(practiceArea => practiceArea.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}