using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[Route("api/reference-data/practice-areas")]
public class PracticeAreasController: ReferenceDataControllerBase<PracticeArea>
{
    public PracticeAreasController(IReferenceDataService<PracticeArea> service) : base(service) { }
}