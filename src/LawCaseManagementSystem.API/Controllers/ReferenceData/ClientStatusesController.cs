using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[Route("api/reference-data/client-statuses")]
public class ClientStatusesController : ReferenceDataControllerBase<ClientStatus>
{
    public ClientStatusesController(
        IReferenceDataService<ClientStatus> service)
        : base(service)
    {
    }
}