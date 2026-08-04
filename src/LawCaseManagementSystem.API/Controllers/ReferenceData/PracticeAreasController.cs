using LawCaseManagementSystem.Application.ReferenceData.DTOs;
using LawCaseManagementSystem.Application.ReferenceData.Interfaces;
using LawCaseManagementSystem.Domain.Entities.ReferenceData;
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

    [HttpPost]
    public async Task<ActionResult<ReferenceDataDto>> CreatePracticeArea(CreateReferenceDataDto dto)
    {
        try
        {
            var result = await _practiceAreaService.CreatePracticeArea(dto);

            return CreatedAtAction(
                nameof(GetPracticeAreaById),
                new { id = result.Id },
                result);
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
    public async Task<ActionResult<ReferenceDataDto>> UpdatePracticeArea(Guid id, UpdateReferenceDataDto dto)
    {
        try
        {
            var result =
                await _practiceAreaService.UpdatePracticeArea(id, dto);

            return result is null ? NotFound() : Ok(result);
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id:guid}/activate")]
    public async Task<IActionResult> ActivatePracticeArea(Guid id)
    {
        var success = await _practiceAreaService.SetPracticeAreaActive(id, true);

        return success ? NoContent() : NotFound();
    }

    [HttpPatch("{id:guid}/deactivate")]
    public async Task<IActionResult> DeactivatePracticeArea(Guid id)
    {
        var success =
            await _practiceAreaService.SetPracticeAreaActive(id, false);

        return success ? NoContent() : NotFound();
    }
}

