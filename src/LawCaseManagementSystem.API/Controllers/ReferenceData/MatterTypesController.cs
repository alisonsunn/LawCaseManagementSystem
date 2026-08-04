using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[Route("api/reference-data/matter-types")]
public class MatterTypesController : ReferenceDataControllerBase<MatterType>
{
    public MatterTypesController(IReferenceDataService<MatterType> service) : base(service) { }
}
