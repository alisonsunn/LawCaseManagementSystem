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
    public async Task<ActionResult<List<ReferenceDataDto>>> GetPracticeAreas(
        [FromQuery] bool includeInactive = false)
    {
        var practiceAreas = await _practiceAreaService.GetPracticeAreas(includeInactive);
        return Ok(practiceAreas);
    }

    [HttpPost]
    public async Task<ActionResult<ReferenceDataDto>> CreatePracticeArea(CreateReferenceDataDto createReferenceDataDto)
    {
        try
        {
            var result = await _practiceAreaService.CreatePracticeArea(createReferenceDataDto);
            return CreatedAtAction(nameof(GetPracticeAreaById), new { id = result.Id }, result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReferenceDataDto>> GetPracticeAreaById(Guid id)
    {
        var result = await _practiceAreaService.GetPracticeAreaById(id);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<ReferenceDataDto>> UpdatePracticeArea(
        Guid id,
        UpdateReferenceDataDto updateReferenceDataDto)
    {
        try
        {
            var result = await _practiceAreaService.UpdatePracticeArea(id, updateReferenceDataDto);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> ActivatePracticeArea(Guid id)
    {
        var result = await _practiceAreaService.SetPracticeAreaActive(id, true);
        return result ? NoContent() : NotFound();
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> DeactivatePracticeArea(Guid id)
    {
        var result = await _practiceAreaService.SetPracticeAreaActive(id, false);
        return result ? NoContent() : NotFound();
    }
}
