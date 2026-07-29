using System;

namespace LawCaseManagementSystem.Application.ReferenceData.DTOs;

public class CreateReferenceDataDto
{
    public string Name { get; set; } = string.Empty;
    public string? Code { get; set; }
    public int DisplayOrder { get; set; }
}
