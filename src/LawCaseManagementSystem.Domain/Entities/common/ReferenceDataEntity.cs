namespace LawCaseManagementSystem.Domain.Entities.Common;

public abstract class ReferenceDataEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsActive { get; set; } = true;
}