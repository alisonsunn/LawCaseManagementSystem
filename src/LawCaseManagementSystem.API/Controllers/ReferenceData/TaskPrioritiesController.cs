using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[Route("api/reference-data/task-priorities")]
public class TaskPrioritiesController : ReferenceDataControllerBase<TaskPriority>
{
    public TaskPrioritiesController(
        IReferenceDataService<TaskPriority> service)
        : base(service)
    {
    }
}