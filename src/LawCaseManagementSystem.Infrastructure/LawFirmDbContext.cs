namespace LawCaseManagementSystem.Infrastructure;

using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.EntityFrameworkCore;

public class LawFirmDbContext : DbContext
{
    public LawFirmDbContext(DbContextOptions<LawFirmDbContext> options)
        : base(options)
    {
    }

    public DbSet<PracticeArea> PracticeAreas => Set<PracticeArea>();

    public DbSet<MatterType> MatterTypes => Set<MatterType>();

    public DbSet<ClientStatus> ClientStatuses => Set<ClientStatus>();

    public DbSet<TaskPriority> TaskPriorities => Set<TaskPriority>();

    public DbSet<DeadlineType> DeadlineTypes => Set<DeadlineType>();

    public DbSet<DocumentCategory> DocumentCategories => Set<DocumentCategory>();
}
