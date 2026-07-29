using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LawCaseManagementSystem.API.Controllers.ReferenceData;

[ApiController]
[Route("api/reference-data/practice-areas")]
public class PracticeAreasController : ControllerBase
{
    private readonly IPracticeAreaService _practiceAreaService;

    public PracticeAreasController(IPracticeAreaService practiceAreaService)
    {
        _practiceAreaService = practiceAreaService;
    }

    [HttpGet]
    public async Task<ActionResult<List<ReferenceDataDto>>> GetPracticeAreas()
    {
        var practiceAreas = await _practiceAreaService.GetPracticeAreas();
        return Ok(practiceAreas);
    }
}

