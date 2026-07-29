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

    public async Task<List<PracticeArea>> GetPracticeAreas()
    {
        return await  _dbContext.PracticeAreas.Where(practiceArea => practiceArea.IsActive).ToListAsync();
    }
}
