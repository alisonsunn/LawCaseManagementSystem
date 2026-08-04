using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[Route("api/reference-data/deadline-types")]
public class DeadlineTypesController : ReferenceDataControllerBase<DeadlineType>
{
    public DeadlineTypesController(
        IReferenceDataService<DeadlineType> service)
        : base(service)
    {
    }
}